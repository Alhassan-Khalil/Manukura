using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_idleState : IdleState
{
    private Enemy2 enemy;
    public E2_idleState(Entity entity, FiniteStateMachine stateMachine, string amimeBoolName, D_IdleState stateData, Enemy2 enemy) : base(entity, stateMachine, amimeBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgruRange)
        {
            stateMachine.ChangeState(enemy.playerDetectState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
