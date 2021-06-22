using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void logicUpdate()
    {
        base.logicUpdate();
        player.CheckIfShouldFlip(xinput);
        player.SetVelocityX(playerData.movementVelociry * xinput);

        if (!IsExitingState)
        {
            if (xinput == 0)
            {
                stateMachine.ChangeState(player.IdelState);
            }
            else if(yinput == -1)
            {
                stateMachine.ChangeState(player.CrouchMoveState);
            }

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
