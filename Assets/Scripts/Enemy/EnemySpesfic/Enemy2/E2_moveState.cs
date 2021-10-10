using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_moveState : MoveState
{
    private Enemy2 enemy;
    public E2_moveState(Entity entity, FiniteStateMachine stateMachine, string amimeBoolName, D_MoveState stateData, Enemy2 enemy) : base(entity, stateMachine, amimeBoolName, stateData)
    {
        this.enemy = enemy;
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgruRange)
        {
            stateMachine.ChangeState(enemy.playerDetectState);
        }
        else if(!isDetectingLedge || isDetectingWall)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
