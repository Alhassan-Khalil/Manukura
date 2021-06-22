using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xinput;
    protected int yinput;

    protected bool IsTouchingCeiling;

    private bool JumpInput;
    private bool Isgrounded;
    private bool IsTouchingWall;
    private bool GrabInput;
    private bool IsTouchingLedge;
    private bool DashInput;
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        Isgrounded = player.CheckIfGrounded();
        IsTouchingWall = player.CheckIfTouchingWall();
        IsTouchingLedge = player.CheckIfTouchingLedge();
        IsTouchingCeiling = player.CheckForCeiling();

    }

    public override void Enter()
    {
        base.Enter();
        player.JumpState.RestAmountOfJumpsLeft();

        player.DashState.ResetCanDash();
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
        JumpInput = player.InputHandler.JumpInput;
        GrabInput = player.InputHandler.GrabInput;
        DashInput = player.InputHandler.DashInput;

        if (JumpInput && player.JumpState.CanJump() )
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (!Isgrounded)
        {
            player.InAirState.StartCoyoteTime();
            stateMachine.ChangeState(player.InAirState);
        }
        else if(IsTouchingWall && GrabInput && IsTouchingLedge)
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        else if (DashInput && player.DashState.CheckIfCanDash() && !IsTouchingCeiling)
        {
            stateMachine.ChangeState(player.DashState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
