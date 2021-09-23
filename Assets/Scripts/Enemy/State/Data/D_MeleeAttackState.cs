﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackData", menuName = "Data/State Data/Melee Attack State")]
public class D_MeleeAttackState : ScriptableObject
{
    public float attackRadius = 0.5f;
    public float attackDamge = 10f;
    public LayerMask whatIsPlayer;
}
