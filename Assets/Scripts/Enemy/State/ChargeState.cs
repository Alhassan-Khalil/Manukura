using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
    protected D_ChargeState stateData;
    protected bool isPlayerInMinAgroRange;
    protected bool isDectectingLedge;
    protected bool isDectectingWall;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAction;

    public ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isDectectingLedge = core.CollisionSenses.LedgeVertical;
        isDectectingWall = core.CollisionSenses.WallFront;

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocityX(stateData.ChargeSpeed * core.Movement.FacingDirection);
        isChargeTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.SetVelocityX(stateData.ChargeSpeed * core.Movement.FacingDirection);

        if (Time.time >= startTime + stateData.ChrageTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
