using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK_IdleState : IdleState
{
    private Skeleton skeleton;
    public SK_IdleState(Entity entity, FiniteStateMachine stateMachine, string amimeBoolName, D_IdleState stateData, Skeleton skeleton) : base(entity, stateMachine, amimeBoolName, stateData)
    {
        this.skeleton = skeleton;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgruRange)
        {
            stateMachine.ChangeState(skeleton.playerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(skeleton.moveState);
        }

    }
}
