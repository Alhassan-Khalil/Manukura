using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK_ChargeState : ChargeState
{
    private Skeleton skeleton;
    public SK_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Skeleton skeleton) : base(entity, stateMachine, animBoolName, stateData)
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
        else if(!isDectectingLedge || isDectectingWall)
        {
            stateMachine.ChangeState(skeleton.lookForPlayerState);
        }
        else if (isChargeTimeOver)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(skeleton.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(skeleton.lookForPlayerState);
            }
        }
    }
}
