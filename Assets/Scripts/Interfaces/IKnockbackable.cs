using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockbackable 
{
    void knockback(Vector2 angle, float strenth, int direction);
}
