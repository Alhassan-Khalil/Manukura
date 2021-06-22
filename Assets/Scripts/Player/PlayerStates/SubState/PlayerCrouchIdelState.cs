using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchIdelState : PlayerGroundedState
{
    public PlayerCrouchIdelState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity0();
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
            if(xinput != 0)
            {
                stateMachine.ChangeState(player.CrouchMoveState);
            }
            else if(yinput != -1&& !IsTouchingCeiling)
            {
                stateMachine.ChangeState(player.IdelState);
            }
        }

    }
}
