using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK_LookForPlayer : LookForPlayerState
{
    private Skeleton skeleton;
    public SK_LookForPlayer(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayerState stateData, Skeleton skeleton) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.skeleton = skeleton;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerinMinAgroRange)
        {
            stateMachine.ChangeState(skeleton.playerDetectedState);
        }
        else if (isAllTurnTimeDone)
        {
            stateMachine.ChangeState(skeleton.moveState);
        }
    }
}
