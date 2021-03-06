using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    //input 

    private int xinput;


    //check 
    private bool Isgrounded;
    private bool jumpInput;
    private bool jumpuInputStop;
    private bool coyoteTime; //jump from the edge
    private bool wallJumpCoyoteTime; 
    private bool IsJumping;
    private bool IsTouchingWall;
    private bool IsTouchingWallback;
    private bool OldIsTouchingWall;
    private bool OldIsTouchingWallBack;
    private bool IsTouchingLedge;
    private bool GrabInput;
    private bool DashInput;

    private float startWalljumpCoyoteTime;


    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();

        OldIsTouchingWall = IsTouchingWall;
        OldIsTouchingWallBack = IsTouchingWallback;
        Isgrounded = core.CollisionSenses.Ground;
        IsTouchingWall = core.CollisionSenses.WallFront;
        IsTouchingWallback = core.CollisionSenses.WallBack;
        IsTouchingLedge = core.CollisionSenses.LedgeHorizontal;


        if (IsTouchingWall && !IsTouchingLedge)
        {
            player.LedgeClimbState.SetDetectedPosition(player.transform.position);
        }

        if(!wallJumpCoyoteTime && !IsTouchingWall && !IsTouchingWallback && (OldIsTouchingWall || OldIsTouchingWallBack))
        {
            StartWallJumpCoyoteTime();
        }
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        OldIsTouchingWall = false;
        OldIsTouchingWallBack = false;
        IsTouchingWall = false;
        IsTouchingWallback = false;
    }

    public override void logicUpdate()
    {
        base.logicUpdate();

        CheckCoyoteTime();
        CheckWallJumpCoyoteTime();

        xinput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;
        jumpuInputStop = player.InputHandler.JumpInputStop;
        GrabInput = player.InputHandler.GrabInput;
        DashInput = player.InputHandler.DashInput;

        CheckJumpMultipler();

        if (player.InputHandler.AttackInputs[(int)CombatInputs.primaty])
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if (player.InputHandler.AttackInputs[(int)CombatInputs.primaty])
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }
        else if (Isgrounded && core.Movement.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else if (IsTouchingWall && !IsTouchingLedge && !Isgrounded)
        {
            stateMachine.ChangeState(player.LedgeClimbState);
        }
        else if (jumpInput && (IsTouchingWall || IsTouchingWallback || wallJumpCoyoteTime))
        {
            StopWallJumpCoyoteTime();
            IsTouchingWall = core.CollisionSenses.WallFront;
            player.WallJumpState.DeterminWallJumpDirection(IsTouchingWall);
            stateMachine.ChangeState(player.WallJumpState);
        }
        else if (jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (IsTouchingWall && xinput == core.Movement.FacingDirection && core.Movement.CurrentVelocity.y <= 0)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }
        else if (IsTouchingWall && GrabInput &&IsTouchingLedge )
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        else if(DashInput && player.DashState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }
        else
        {
            core.Movement.CheckIfShouldFlip(xinput);
            core.Movement.SetVelocityX(playerData.movementVelociry * xinput);

            player.Anim.SetFloat("Yvelocity", core.Movement.CurrentVelocity.y);
            player.Anim.SetFloat("Xvelocity", Mathf.Abs(core.Movement.CurrentVelocity.x));

        }
    }


    private void CheckJumpMultipler()
    {
        if (IsJumping)
        {
            if (jumpuInputStop)
            {
                core.Movement.SetVelocityY(core.Movement.CurrentVelocity.y * playerData.variableJumpHeightMul);
                IsJumping = false;
            }
            else if (core.Movement.CurrentVelocity.y <= 0f)
            {
                IsJumping = false;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckCoyoteTime()
    {
        if (coyoteTime && Time.time > startTime + playerData.coyoteTime)
        {
            coyoteTime = false;
            player.JumpState.DecreaseAmountOfJumpLeft();
        }
    }
    private void CheckWallJumpCoyoteTime()
    {
        if (wallJumpCoyoteTime && Time.time > startWalljumpCoyoteTime + playerData.coyoteTime)
        {
            coyoteTime = false;
            player.JumpState.DecreaseAmountOfJumpLeft();
        }
    }


    public void StartCoyoteTime() => coyoteTime = true;

    public void StartWallJumpCoyoteTime()
    {
        wallJumpCoyoteTime = true;
        startWalljumpCoyoteTime = Time.time;
    }

    public void StopWallJumpCoyoteTime() => wallJumpCoyoteTime = false;


    public void SetIsJumping() => IsJumping = true;
}
