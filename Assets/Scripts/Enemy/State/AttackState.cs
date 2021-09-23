using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected Transform attackPosition;

    protected bool isAnimtionFinished;
    protected bool isPlayerInMinAgroRang;
    protected bool isPlayerInMaxAgroRang;


    public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerInMinAgroRang = entity.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRang = entity.CheckPlayerInMaxAgruRange();
    }

    public override void Enter()
    {
        base.Enter();
        entity.atsm.attackState = this;
        isAnimtionFinished = false;
        entity.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void triggerAttack()
    {

    }
    public virtual void FinishAttack()
    {
        isAnimtionFinished = true;
    }
}
