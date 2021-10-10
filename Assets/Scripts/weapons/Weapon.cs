using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected SO_WeaponData weaponData = default;

    protected Animator baseAimator;
    protected Animator weaponAnimator;

    protected Core core;

    protected PlayerAttackState state;
    protected int attackCounter;
    

    protected virtual void Awake()
    {
        baseAimator = transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {

        if(attackCounter >= weaponData.AmountOfAttacks)
        {
            attackCounter = 0;
        }
        gameObject.SetActive(true);

        baseAimator.SetBool("attack", true);
        weaponAnimator.SetBool("attack", true);

        baseAimator.SetInteger("attackCounter", attackCounter);
        weaponAnimator.SetInteger("attackCounter", attackCounter);

    }

    public virtual void ExitWeapon()
    {
        baseAimator.SetBool("attack", false);
        weaponAnimator.SetBool("attack", false);

        attackCounter++;

        gameObject.SetActive(false);
    }

    #region Animation Triggers
    public virtual void AnimationFinshTrigger()
    {
        state.AnimationFinishTrigger();
    }
    public virtual void AnimationStartMovementTrigger()
    {
        state.SetPlayerVelocity(weaponData.MovementSpeed[attackCounter]);
    }
    public virtual void AnimationStoptMovementTrigger()
    {
        state.SetPlayerVelocity(0f);
    }
    public virtual void AnimationTurnOffFlipTrigger()
    {
        state.SetFlipCheck(false);
    }
    public virtual void AnimationTurnOnFlipTrigger()
    {
        state.SetFlipCheck(true);
    }

    public virtual void AnimationActionTrigger()
    {

    }

    #endregion

    public void InitializeWeapon(PlayerAttackState state, Core core)
    {
        this.state = state;
        this.core = core;
    }
}
