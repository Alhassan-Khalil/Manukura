using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Entity
{
    public SK_IdleState idleState { get; private set; }
    public SK_MoveState moveState { get; private set; }
    public SK_PlayerDetectedState playerDetectedState { get; private set; }
    public SK_ChargeState chargeState { get; private set; }
    public SK_LookForPlayer lookForPlayerState { get; private set; }
    public SK_MeleeAttackState meleeAttackState { get; private set; }
    public SK_DeadState deadState { get; private set; }



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
    private D_DeadState DeadStateData = default;


    [SerializeField]
    private Transform meleeAttackPos = default;

    public override void Awake()
    {
        base.Awake();

        moveState = new SK_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new SK_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new SK_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new SK_ChargeState(this, stateMachine, "charge", ChargeStateData, this);
        lookForPlayerState = new SK_LookForPlayer(this, stateMachine, "lookForPlayer", LookForPlayerData, this);
        meleeAttackState = new SK_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPos,meleeAttackData, this);
        deadState = new SK_DeadState(this, stateMachine, "dead", DeadStateData, this);
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
}
