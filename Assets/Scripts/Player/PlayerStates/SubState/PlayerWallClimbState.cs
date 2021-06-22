using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallClimbState : PlayerTouchingWallState
{
    public PlayerWallClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void logicUpdate()
    {
        base.logicUpdate();
        if (!IsExitingState)
        {
            player.SetVelocityY(playerData.WallClimbVelocity);

            if (yinput != 1)
            {
                stateMachine.ChangeState(player.WallGrabState);
            }

        }
    }
}
