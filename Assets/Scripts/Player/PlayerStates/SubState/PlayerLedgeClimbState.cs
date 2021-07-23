using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{

    private Vector2 detectedPos;
    private Vector2 cornerPos;
    public Vector2 startPos;
    public Vector2 stopPos;
    private Vector2 workspace;

    private bool IsHanging;
    private bool IsClimbing;
    private bool jumpInput;
    private bool IsTouchingceiling;

    private int xInput;
    private int yInput;

    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        player.Anim.SetBool("climbLedge", false);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        IsHanging = true;
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocity0();
        player.transform.position = detectedPos;
        cornerPos = DeterminCornerPos();

        startPos.Set(cornerPos.x - (core.Movement.FacingDirection * playerData.startOffset.x), cornerPos.y - playerData.startOffset.y);
        stopPos.Set(cornerPos.x + (core.Movement.FacingDirection * playerData.stopOffset.x), cornerPos.y + playerData.stopOffset.y);

        player.transform.position = startPos;
    }

    public override void Exit()
    {
        base.Exit();
        IsHanging = false;
        if (IsClimbing)
        {
            player.transform.position = stopPos;
            IsClimbing = false;
        }
    }

    public override void logicUpdate()
    {
        base.logicUpdate();
        if (IsAnimationFinihed)
        {
            if (IsTouchingceiling)
            {
                stateMachine.ChangeState(player.CrouchIdelState);
            }
            else
            {

                stateMachine.ChangeState(player.IdelState);
            }
        }
        else
        {
            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.JumpInput;


            core.Movement.SetVelocity0();
            player.transform.position = startPos;

            if (xInput == core.Movement.FacingDirection && IsHanging && !IsClimbing)
            {
                CheckForSpace();
                IsClimbing = true;
                player.Anim.SetBool("climbLedge", true);
            }
            else if (yInput == -1 && IsHanging && !IsClimbing)
            {
                stateMachine.ChangeState(player.InAirState);
            }
            else if (jumpInput && !IsClimbing)
            {
                player.WallJumpState.DeterminWallJumpDirection(true);
                stateMachine.ChangeState(player.WallJumpState);
            }
        }
    }

    public void SetDetectedPosition(Vector2 pos) => detectedPos = pos;

    private void CheckForSpace()
    {
        IsTouchingceiling = Physics2D.Raycast(cornerPos + (Vector2.up * 0.015f) + (Vector2.right* core.Movement.FacingDirection * 0.015f), Vector2.up , playerData.standColliderHeight, core.CollisionSenses.WhatIsGround);
    }

    private Vector2 DeterminCornerPos()
    {
        RaycastHit2D xHit = Physics2D.Raycast(core.CollisionSenses.WallCheck.position, Vector2.right * core.Movement.FacingDirection, core.CollisionSenses.WallCheckDistance, core.CollisionSenses.WhatIsGround);
        float xDist = xHit.distance;
        workspace.Set((xDist + 0.015f) * core.Movement.FacingDirection, 0f);
        RaycastHit2D yHit = Physics2D.Raycast(core.CollisionSenses.LedgeCheck.position + (Vector3)(workspace), Vector2.down, core.CollisionSenses.LedgeCheck.position.y - core.CollisionSenses.WallCheck.position.y + 0.015f, core.CollisionSenses.WhatIsGround);
        float yDist = yHit.distance;

        workspace.Set(core.CollisionSenses.WallCheck.position.x + (xDist * core.Movement.FacingDirection), core.CollisionSenses.LedgeCheck.position.y - yDist);

        return workspace;
    }
}
