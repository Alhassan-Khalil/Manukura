using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK_PlayerDetectedState : PlayerDetectedState
{
    private Skeleton skeleton;
    public SK_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData, Skeleton skeleton) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.skeleton = skeleton;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(skeleton.meleeAttackState);
        }
        else if (performLongRangeAction)
        {
            stateMachine.ChangeState(skeleton.chargeState);

        }
        else if (!isPlayerInMaxAgruRange)
        {
            stateMachine.ChangeState(skeleton.lookForPlayerState);
        }
        else if (!isDetectingLedge)
        {
            core.Movement.Flip();
            stateMachine.ChangeState(skeleton.moveState);
        }
    }
}
