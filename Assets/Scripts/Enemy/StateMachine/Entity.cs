using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    public D_Entity entityData;
    public int FacingDirection { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public Animator Anim { get; private set; }
    public GameObject AliveGO { get; private set; }
    public AnimationToStatemachine atsm { get; protected set; }
    public int lastDamageDirction { get; private set; }


    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;
    [SerializeField]
    private Transform groundCheck;

    private float currentHealth;
    private float currentStunResistance;
    private float lastDamageTime;

    private Vector2 velocityWorkSpace;

    protected bool isStunned;
    protected bool isDead;


    public virtual void Start()
    {
        FacingDirection = 1;
        currentHealth = entityData.maxHealth;
        currentStunResistance = entityData.stunResistance;

        AliveGO = transform.Find("Alive").gameObject;
        Rb = AliveGO.GetComponent<Rigidbody2D>();
        Anim = AliveGO.GetComponent<Animator>();
        atsm = AliveGO.GetComponent<AnimationToStatemachine>(); 
        stateMachine = new FiniteStateMachine();

    }
    public virtual void Update()
    {
        stateMachine.CurrentState.LogicUpdate();

        Anim.SetFloat("yVelocity", Rb.velocity.y);


        if(Time.time >= lastDamageTime + entityData.stunRecovrytime)
        {
            RestStunResistance();
        }
    }

    public virtual void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkSpace.Set(FacingDirection * velocity, Rb.velocity.y);
        Rb.velocity = velocityWorkSpace;
    }
    public virtual void SetVelocity(float velocity,Vector2 angle, int direction)
    {
        angle.Normalize();
        velocityWorkSpace.Set(angle.x * velocity * direction,angle.y *velocity);
        Rb.velocity = velocityWorkSpace;
    }

    public virtual void Flip()
    {
        FacingDirection *= -1;
        AliveGO.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void DamageHop(float velocity)
    {
        velocityWorkSpace.Set(Rb.velocity.x, velocity);
        Rb.velocity = velocityWorkSpace;
    }

    public virtual void RestStunResistance()
    {
        isStunned = false;
        currentStunResistance = entityData.stunResistance;
    }


    public virtual void Damage(AttackDetails attackDetails)
    {
        lastDamageTime = Time.time;

        currentHealth -= attackDetails.damageAmount;
        currentStunResistance -= attackDetails.stunDamageAmount;

        DamageHop(entityData.damageHopSpeed);

        Instantiate(entityData.HitParticle, AliveGO.transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        if(attackDetails.position.x > AliveGO.transform.position.x)
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
    }

    public virtual bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, entityData.groundCheckRadius, entityData.whatIsGraound);
    }
    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, AliveGO.transform.right, entityData.wallCheckDistance, entityData.whatIsGraound);
    }
    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGraound);

    }
    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, AliveGO.transform.right, entityData.minAgruDistance, entityData.whatIsPlayer);

    }
    public virtual bool CheckPlayerInMaxAgruRange()
    {
        return Physics2D.Raycast(playerCheck.position, AliveGO.transform.right, entityData.maxAgruDistance, entityData.whatIsPlayer);

    }
    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, AliveGO.transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }
    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * FacingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));

        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance), 0.2f);
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAgruDistance), 0.2f);
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgruDistance), 0.2f);

    }
}
