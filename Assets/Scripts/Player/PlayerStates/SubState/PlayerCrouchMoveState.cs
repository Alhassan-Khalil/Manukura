using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchMoveState : PlayerGroundedState
{
    public PlayerCrouchMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetColliderHeight(playerData.crouchColliderHeight);
    }

    public override void Exit()
    {
        base.Exit();
        player.SetColliderHeight(playerData.standColliderHeight);
    }

    public override void logicUpdate()
    {
        base.logicUpdate();

        if (!IsExitingState)
        {

            player.CheckIfShouldFlip(xinput);
            player.SetVelocityX(playerData.crouchMovementVelocity * xinput);
            if(xinput  == 0)
            {
                stateMachine.ChangeState(player.CrouchIdelState );
            }
            else if (yinput != -1 && !IsTouchingCeiling)
            {
                stateMachine.ChangeState(player.MoveState);
            }
        }
    }
}
