using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilitState
{
    private int amountOfJumpLeft;
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
        amountOfJumpLeft = playerData.amountOfJump;
    }

    public override void Enter()
    {

        base.Enter();
        player.InputHandler.UseJumpInput();
        player.SetVelocityY(playerData.jumpvelocity);
        //call the ability
        IsAbilityDone = true;
        amountOfJumpLeft--;
        player.InAirState.SetIsJumping();
    }

    public bool CanJump()
    {
        if(amountOfJumpLeft> 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void RestAmountOfJumpsLeft() => amountOfJumpLeft = playerData.amountOfJump;

    public void DecreaseAmountOfJumpLeft() => amountOfJumpLeft--;
}
