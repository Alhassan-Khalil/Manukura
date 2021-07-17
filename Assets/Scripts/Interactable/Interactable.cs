using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public UnityEvent interactAction;
   // public bool intractKey;


    // Start is called before the first frame update
    public void intractKeyPressed()
    {   
        if (isInRange)
        {
            //intractKey = true;
            interactAction.Invoke();
        }
    }

    // Update is called once per frame



/*    void Update()
    {
        if (isInRange && intractKey)
        {
            interactAction.Invoke();
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player is in range");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            //intractKey = false;
            Debug.Log("Player is in range");
        }
    }
}
