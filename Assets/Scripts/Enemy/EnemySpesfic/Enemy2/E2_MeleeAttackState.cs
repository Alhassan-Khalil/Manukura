using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_MeleeAttackState : MeleeAttackState
{
    private Enemy2 enemy;
    public E2_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState staeData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, attackPosition, staeData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimtionFinished)
        {
            if (isPlayerInMinAgroRang)
            {
                stateMachine.ChangeState(enemy.playerDetectState);
            }
            else if (!isPlayerInMinAgroRang)
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }
}
