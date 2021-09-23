using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base State")]
public class D_Entity : ScriptableObject
{

    public float maxHealth = 30f;
    public float damageHopSpeed = 3f;

    public float wallCheckDistance =0.7f ;
    public float ledgeCheckDistance=0.4f;
    public float groundCheckRadius = 0.3f;

    public float minAgruDistance = 3f;
    public float maxAgruDistance = 4f;

    public float stunResistance = 3f;
    public float stunRecovrytime = 2f;

    public float closeRangeActionDistance = 1f;

    public GameObject HitParticle;

    public LayerMask whatIsGraound;
    public LayerMask whatIsPlayer;



}
