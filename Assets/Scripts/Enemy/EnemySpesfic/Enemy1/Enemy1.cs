using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_PlayerDetectedState playerDetectedState { get; private set; }
    public E1_ChargeState chargeState { get; private set; }
    public E1_LookForPlayerState lookForPlayerState { get; private set; }
    public E1_MeleeAttackState meleeAttackState { get; private set; }
    public E1_StunState stunState { get; private set; }
    public E1_DeadState deadState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData = default;
    [SerializeField]
    private D_MoveState moveStateData = default;
    [SerializeField]
    private D_PlayerDetectedState playerDetectedData = default;
    [SerializeField]
    private D_ChargeState ChargeStateData = default;
    [SerializeField]
    private D_LookForPlayerState LookForPlayerData = default;
    [SerializeField]
    private D_MeleeAttackState meleeAttackData = default;
    [SerializeField]
    private D_StunState StunStateData = default;
    [SerializeField]
    private D_DeadState DeadStateData = default;


    [SerializeField]
    private Transform meleeAttackPos = default;

    public override void Awake()
    {
        base.Awake();

        moveState = new E1_MoveState(this, stateMachine, "move", moveStateData,this);
        idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new E1_ChargeState(this, stateMachine, "charge", ChargeStateData, this);
        lookForPlayerState = new E1_LookForPlayerState(this, stateMachine, "lookForPlayer", LookForPlayerData, this);
        meleeAttackState = new E1_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPos, meleeAttackData,this);
        stunState = new E1_StunState(this, stateMachine, "stun", StunStateData, this);
        deadState = new E1_DeadState(this, stateMachine, "dead", DeadStateData, this);


    }

    private void Start()
    {
        stateMachine.Initialize(moveState);
        
    }


    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPos.position, meleeAttackData.attackRadius);
    }

/*    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (isDead)
        {
            stateMachine.ChangeState(deadState);
        }
        else if (isStunned && stateMachine.CurrentState != stunState)
        {
            stateMachine.ChangeState(stunState);
        }

    }*/
}
