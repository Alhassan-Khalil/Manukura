using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void logicUpdate()
    {
        base.logicUpdate();

        if (!IsExitingState)
        {
            if(xinput != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else if (IsAnimationFinihed)
            {
                stateMachine.ChangeState(player.IdelState);
            }

        }

    }

}
