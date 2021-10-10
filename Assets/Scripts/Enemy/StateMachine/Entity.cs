using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    public D_Entity entityData;
    public Animator Anim { get; private set; }
    public AnimationToStatemachine atsm { get; protected set; }
    public int lastDamageDirction { get; private set; }
    public Core core { get; private set; }


    [SerializeField]
    private Transform wallCheck = default;
    [SerializeField]
    private Transform ledgeCheck = default;
    [SerializeField]
    private Transform playerCheck = default;
    [SerializeField]
    private Transform groundCheck = default;

    private float currentHealth;
    private float currentStunResistance;
    private float lastDamageTime = default;

    private Vector2 velocityWorkSpace;

    protected bool isStunned;
    protected bool isDead;


    public virtual void Awake()
    {
        core = GetComponentInChildren <Core>();

        currentHealth = entityData.maxHealth;
        currentStunResistance = entityData.stunResistance;

        Anim = GetComponent<Animator>();
        atsm = GetComponent<AnimationToStatemachine>(); 
        stateMachine = new FiniteStateMachine();

    }
    public virtual void Update()
    {
        core.LogicUpdate();
        stateMachine.CurrentState.LogicUpdate();

        Anim.SetFloat("yVelocity", core.Movement.RB.velocity.y);


        if(Time.time >= lastDamageTime + entityData.stunRecovrytime)
        {
            RestStunResistance();
        }
    }

    public virtual void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }



    public virtual void DamageHop(float velocity)
    {
        velocityWorkSpace.Set(core.Movement.RB.velocity.x, velocity);
        core.Movement.RB.velocity = velocityWorkSpace;
    }

    public virtual void RestStunResistance()
    {
        isStunned = false;
        currentStunResistance = entityData.stunResistance;
    }


/*    public virtual void Damage(AttackDetails attackDetails)
    {
        lastDamageTime = Time.time;

        currentHealth -= attackDetails.damageAmount;
        currentStunResistance -= attackDetails.stunDamageAmount;

        DamageHop(entityData.damageHopSpeed);

        Instantiate(entityData.HitParticle, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        if(attackDetails.position.x > transform.position.x)
        {
            lastDamageDirction = -1;
        }
        else
        {
            lastDamageDirction = 1;
        }

        if(currentStunResistance <= 0)
        {
            isStunned = true;
        }
        if(currentHealth <= 0)
        {
            isDead = true;
        }
    }*/


    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAgruDistance, entityData.whatIsPlayer);

    }
    public virtual bool CheckPlayerInMaxAgruRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxAgruDistance, entityData.whatIsPlayer);

    }
    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }
    public virtual void OnDrawGizmos()
    {
        if(core != null)
        {

            Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * core.Movement.FacingDirection * entityData.wallCheckDistance));
            Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));

            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance), 0.2f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAgruDistance), 0.2f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgruDistance), 0.2f);
        }

    }
}
