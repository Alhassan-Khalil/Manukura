using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdelState : PlayerGroundedState
{
    public PlayerIdelState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void logicUpdate()
    {
        base.logicUpdate();

        if (!IsExitingState)
        {
            if (xinput != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else if (yinput == -1 )
            {
                stateMachine.ChangeState(player.CrouchIdelState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
