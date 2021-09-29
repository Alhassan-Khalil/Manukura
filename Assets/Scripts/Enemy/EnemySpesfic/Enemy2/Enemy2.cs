using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Entity
{
    public E2_moveState moveState { get; private set; }
    public E2_idleState idleState { get; private set; }
    public E2_PlayerDetectState playerDetectState { get; private set; }
    public E2_MeleeAttackState meleeAttackState { get; private set; }
    public E2_LookForPlayerState lookForPlayerState { get; private set; }
    public E2_StunState stunState { get; private set; }
    public E2_DeadState deadState { get; private set; }
    public E2_DodgeState dodgeState { get; protected set; }
    public E2_RangedAttackState rangedAttackState { get; private set; }



    [SerializeField]
    private D_IdleState idleStateData = default;
    [SerializeField]
    private D_MoveState moveStateData = default;
    [SerializeField]
    private D_PlayerDetectedState playerDetectedData = default;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData = default;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData = default;
    [SerializeField]
    private D_StunState stunStatedata = default;
    [SerializeField]
    private D_DeadState deadStateData = default;
    [SerializeField]
    public D_DodgeState dodgeStateData = default;
    [SerializeField]
    public D_RangedAttackState rangedAttackStateData = default;


    [SerializeField]
    private Transform meleeAttackPos = default, rangedAttackPos = default;

    public override void Awake()
    {
        base.Awake();

        moveState = new E2_moveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E2_idleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectState = new E2_PlayerDetectState(this, stateMachine, "playerDetected", playerDetectedData, this);
        meleeAttackState = new E2_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPos, meleeAttackStateData, this);
        lookForPlayerState = new E2_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new E2_StunState(this, stateMachine, "stun", stunStatedata, this);
        deadState = new E2_DeadState(this, stateMachine, "dead", deadStateData, this);
        dodgeState = new E2_DodgeState(this, stateMachine, "dodge", dodgeStateData, this);
        rangedAttackState = new E2_RangedAttackState(this, stateMachine, "rangedAttack", rangedAttackPos,rangedAttackStateData, this);


    }


    private void Start()
    {
        
        stateMachine.Initialize(moveState);
    }

/*    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (isDead)
        {
            stateMachine.ChangeState(deadState);
        }
        else if(isStunned && stateMachine.CurrentState != stunState)
        {
            stateMachine.ChangeState(stunState);
        }
        else if (CheckPlayerInMinAgroRange())
        {
            stateMachine.ChangeState(rangedAttackState);
        }
        else if (!CheckPlayerInMinAgroRange())
        {
            lookForPlayerState.SetTurnImmediately(true);
            stateMachine.ChangeState(lookForPlayerState);
        }
    }*/

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPos.position, meleeAttackStateData.attackRadius);

    }
}
