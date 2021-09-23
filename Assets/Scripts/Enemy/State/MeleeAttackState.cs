using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    protected D_MeleeAttackState stateData;
    protected AttackDetails attackDetails;
    public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState staeData) : base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = staeData;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();

        attackDetails.damageAmount = stateData.attackDamge;
        attackDetails.position = entity.AliveGO.transform.position;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void triggerAttack()
    {
        base.triggerAttack();

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius,stateData.whatIsPlayer); ;

        foreach (Collider2D collider in detectedObjects)
        {
           // collider.transform.SendMessage("Damage", attackDetails);
        }
    }
}
