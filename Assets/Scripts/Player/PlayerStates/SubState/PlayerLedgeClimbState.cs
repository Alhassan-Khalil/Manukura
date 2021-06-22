using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{

    private Vector2 detectedPos;
    private Vector2 cornerPos;
    public Vector2 startPos;
    public Vector2 stopPos;

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
        player.SetVelocity0();
        player.transform.position = detectedPos;
        cornerPos = player.DeterminCornerPos();

        startPos.Set(cornerPos.x - (player.FacingDirection * playerData.startOffset.x), cornerPos.y - playerData.startOffset.y);
        stopPos.Set(cornerPos.x + (player.FacingDirection * playerData.stopOffset.x), cornerPos.y + playerData.stopOffset.y);

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


            player.SetVelocity0();
            player.transform.position = startPos;

            if (xInput == player.FacingDirection && IsHanging && !IsClimbing)
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
        IsTouchingceiling = Physics2D.Raycast(cornerPos + (Vector2.up * 0.015f) + (Vector2.right* player.FacingDirection * 0.015f), Vector2.up , playerData.standColliderHeight,playerData.whatIsGround);
    }
}
