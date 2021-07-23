using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerAbilitState
{
    private int wallJumpDirection;
    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.UseJumpInput();
        player.JumpState.RestAmountOfJumpsLeft(); 
        core.Movement.SetVelocity(playerData.WallJumpVelocity, playerData.WallJumpAngle, wallJumpDirection);
        core.Movement.CheckIfShouldFlip(wallJumpDirection);
        player.JumpState.DecreaseAmountOfJumpLeft();
    }

    public override void logicUpdate()
    {
        base.logicUpdate();
        player.Anim.SetFloat("Yvelocity", core.Movement.CurrentVelocity.y);
        player.Anim.SetFloat("Xvelocity",Mathf.Abs(core.Movement.CurrentVelocity.x));

        if (Time.time >= startTime + playerData.WallJumpTime)
        {
            IsAbilityDone = true;
        }

    }
    public void DeterminWallJumpDirection(bool IsTouchingWall)
    {
        if (IsTouchingWall)
        {
            wallJumpDirection = -core.Movement.FacingDirection;
        }
        else
        {
            wallJumpDirection = core.Movement.FacingDirection;
        }
    }
}
