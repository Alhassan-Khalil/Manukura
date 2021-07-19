using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected Animator baseAimator;
    protected Animator weaponAnimator;
    protected PlayerAttackState state;
    

    protected virtual void Start()
    {
        baseAimator = transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        baseAimator.SetBool("attack", true);
        weaponAnimator.SetBool("attack", true);
    }

    public virtual void ExitWeapon()
    {
        baseAimator.SetBool("attack", false);
        weaponAnimator.SetBool("attack", false);

        gameObject.SetActive(false);
    }

    #region Animation Triggers
    public virtual void AnimationFinshTrigger()
    {
        state.AnimationFinishTrigger();
    }
    #endregion

    public void InitializeWeapon(PlayerAttackState state)
    {
        this.state = state;
    }
}
