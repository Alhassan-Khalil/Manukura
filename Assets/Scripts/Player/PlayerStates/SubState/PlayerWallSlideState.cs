using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void logicUpdate()
    {
        base.logicUpdate();
        if (!IsExitingState)
        {
            player.SetVelocityY(-playerData.wallSlideVelocity);

            if(GrabInput && yinput ==0 && !IsExitingState)
            {
                stateMachine.ChangeState(player.WallGrabState);
            }

        }
    }
}
