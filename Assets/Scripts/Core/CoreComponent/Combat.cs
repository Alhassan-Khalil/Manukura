using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable
{

    private bool isKnockbackActive;
    private float knockbackStartTime;

    [SerializeField] private float maxKnockbackTime = 0.2f;

    public override void LogicUpdate()
    {
        checkKnockback();
    }

    public void Damage(float amount)
    {
        Debug.Log(core.transform.parent.name + " Damgaed! ");
        core.Stats.DecreaseHealth(amount);
    }

    public void knockback(Vector2 angle, float strenth, int direction)
    {
        core.Movement.SetVelocity(strenth, angle, direction);
        core.Movement.CanSetVelcity = false;
        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    private void checkKnockback()
    {
        if(isKnockbackActive && core.Movement.CurrentVelocity.y <= 0.01f && (core.CollisionSenses.Ground || Time.time >= knockbackStartTime + maxKnockbackTime))
        {
            isKnockbackActive = false;
            core.Movement.CanSetVelcity = true;
        }
    }
}
