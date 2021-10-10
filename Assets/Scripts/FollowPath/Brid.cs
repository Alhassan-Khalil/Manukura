using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brid : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform GFX;

    private float x;
    private float xCurrent;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        xCurrent = Mathf.Abs(transform.position.x);
        x = xCurrent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

 

/*        if (Mathf.Abs(transform.position.x) >= xCurrent)
        {
            Debug.Log("i should rotate");
            //GFX.Rotate(0.0f, 180.0f, 0.0f);
            GFX.localScale = new Vector3(-1f, 1f, 1f);

        }
        else if (Mathf.Abs(transform.position.x) <= xCurrent)
        {
            Debug.Log("i should rotate again ");
            //GFX.localScale = new Vector3(1f, 1f, 1f);
            GFX.Rotate(0.0f, 0.0f, 0.0f);

        }*/
    }
}