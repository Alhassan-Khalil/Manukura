using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

[CreateAssetMenu(fileName = "newChargeData", menuName = "Data/State Data/Charge State")]
public class D_ChargeState : ScriptableObject
{
    public float ChargeSpeed = 6f;
    public float ChrageTime = 2f;
}
