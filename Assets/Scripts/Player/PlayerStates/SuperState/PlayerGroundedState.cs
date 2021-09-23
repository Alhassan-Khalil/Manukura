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
        Isgrounded = core.CollisionSenses.Ground;
        IsTouchingWall = core.CollisionSenses.WallFront;
        IsTouchingLedge = core.CollisionSenses.LedgeHorizontal;
        IsTouchingCeiling = core.CollisionSenses.Ceiling;

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
    // hhhehheheheehhe
    public override void logicUpdate()
    {
        base.logicUpdate();

        xinput = player.InputHandler.NormInputX;
        yinput = player.InputHandler.NormInputY;
        JumpInput = player.InputHandler.JumpInput;
        GrabInput = player.InputHandler.GrabInput;
        DashInput = player.InputHandler.DashInput;

        if (player.InputHandler.AttackInputs[(int)CombatInputs.primaty] && !IsTouchingCeiling)
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if (player.InputHandler.AttackInputs[(int)CombatInputs.primaty] && !IsTouchingCeiling)
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }
        else if (JumpInput && player.JumpState.CanJump() )
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
