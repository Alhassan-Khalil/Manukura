using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK_MeleeAttackState : MeleeAttackState
{
    private Skeleton skeleton;

    public SK_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState staeData, Skeleton skeleton) : base(entity, stateMachine, animBoolName, attackPosition, staeData)
    {
        this.skeleton = skeleton;
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimtionFinished)
        {
            if (isPlayerInMinAgroRang)
            {
                stateMachine.ChangeState(skeleton.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(skeleton.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }

    public override void triggerAttack()
    {
        base.triggerAttack();
    }
}
