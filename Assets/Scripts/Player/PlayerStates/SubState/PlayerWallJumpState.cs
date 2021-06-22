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
        player.SetVelocity(playerData.WallJumpVelocity, playerData.WallJumpAngle, wallJumpDirection);
        player.CheckIfShouldFlip(wallJumpDirection);
        player.JumpState.DecreaseAmountOfJumpLeft();
    }

    public override void logicUpdate()
    {
        base.logicUpdate();
        player.Anim.SetFloat("Yvelocity", player.CurrentVelocity.y);
        player.Anim.SetFloat("Xvelocity",Mathf.Abs(player.CurrentVelocity.x));

        if (Time.time >= startTime + playerData.WallJumpTime)
        {
            IsAbilityDone = true;
        }

    }
    public void DeterminWallJumpDirection(bool IsTouchingWall)
    {
        if (IsTouchingWall)
        {
            wallJumpDirection = -player.FacingDirection;
        }
        else
        {
            wallJumpDirection = player.FacingDirection;
        }
    }
}
