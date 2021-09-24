using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : State
{
    protected D_LookForPlayerState stateData;

    protected bool isPlayerinMinAgroRange;
    protected bool isAllTurnDone;
    protected bool isAllTurnTimeDone;
    protected bool TurnImmediately;

    protected float lastTurnTime;
    protected int amountOfTurnDone;
    public LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayerState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerinMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        isAllTurnDone = false;
        isAllTurnTimeDone = false;

        lastTurnTime = startTime;
        amountOfTurnDone = 0;

        core.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (TurnImmediately)
        {
            core.Movement.Flip();
            lastTurnTime = Time.time;
            amountOfTurnDone++;
            TurnImmediately = false;
        }
        else if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && !isAllTurnDone)
        {
            core.Movement.Flip();
            lastTurnTime = Time.time;
            amountOfTurnDone++;
        }
        if (amountOfTurnDone >= stateData.amountOfTurn)
        {
            isAllTurnDone = true;
        }

        if(Time.time >= lastTurnTime + stateData.timeBetweenTurns && isAllTurnDone)
        {
            isAllTurnTimeDone = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public void SetTurnImmediately(bool flip)
    {
        TurnImmediately = flip;
    }
}
