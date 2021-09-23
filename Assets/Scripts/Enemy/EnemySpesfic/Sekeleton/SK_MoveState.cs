using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK_MoveState : MoveState
{
    private Skeleton skeleton;
    public SK_MoveState(Entity entity, FiniteStateMachine stateMachine, string amimeBoolName, D_MoveState stateData, Skeleton skeleton) : base(entity, stateMachine, amimeBoolName, stateData)
    {
        this.skeleton = skeleton;
    }

    public override void Enter()
    {
        base.Enter();
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
}
