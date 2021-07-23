using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchingWallState : PlayerState
{
    protected bool Isgrounded;
    protected bool IsTouchingWall;
    protected bool GrabInput;
    protected bool JumpuInput;
    protected bool IstouchingLedge;
    protected int xinput;
    protected int yinput;
    public PlayerTouchingWallState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoCheck()
    {
        base.DoCheck();
        Isgrounded = core.CollisionSenses.Ground;
        IsTouchingWall = core.CollisionSenses.WallFront;
        IstouchingLedge = core.CollisionSenses.Ledge;

        if(IsTouchingWall && !IstouchingLedge)
        {
            player.LedgeClimbState.SetDetectedPosition(player.transform.position);
        }
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void logicUpdate()
    {
        base.logicUpdate();
        xinput = player.InputHandler.NormInputX;
        yinput = player.InputHandler.NormInputY;
        GrabInput = player.InputHandler.GrabInput;
        JumpuInput = player.InputHandler.JumpInput;


        if (JumpuInput)
        {
            player.WallJumpState.DeterminWallJumpDirection(IsTouchingWall);
            stateMachine.ChangeState(player.WallJumpState);
        }
        else if (Isgrounded && !GrabInput )
        {
            stateMachine.ChangeState(player.IdelState);
        }
        else if (!IsTouchingWall || (xinput != core.Movement.FacingDirection && !GrabInput))
        {
            stateMachine.ChangeState(player.InAirState);
        }
        else if (IsTouchingWall && !IstouchingLedge)
        {
            stateMachine.ChangeState(player.LedgeClimbState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
