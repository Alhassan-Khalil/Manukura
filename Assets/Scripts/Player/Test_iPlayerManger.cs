using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_iPlayerManger : MonoBehaviour
{
    public int KeyCount;
    public void pickupKey()
    {
        KeyCount = 1;
    }
    public void UseKey()
    {
        KeyCount--;
        Debug.Log("used a key");
    }
}
