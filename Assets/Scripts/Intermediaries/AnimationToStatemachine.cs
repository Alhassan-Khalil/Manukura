using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStatemachine : MonoBehaviour
{
public AttackState attackState;

private void TriggerAttack()
{
    attackState.triggerAttack();
}

private void FinishAttack()
{
    attackState.FinishAttack();
}
}
