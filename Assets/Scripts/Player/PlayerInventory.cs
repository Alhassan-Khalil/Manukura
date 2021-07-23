using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int KeyCount;

    public Weapon[] weapons;


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
