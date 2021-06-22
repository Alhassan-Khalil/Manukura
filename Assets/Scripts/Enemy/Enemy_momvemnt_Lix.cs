using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_momvemnt_L : MonoBehaviour
{

    [SerializeField] private float movemntSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 groundCheckDistance;

    [SerializeField]
    private bool
        canmove,
        Flipped;


    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (canmove)
            
        
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, groundCheckDistance, 0, LayerMask.GetMask("ground"));
    }


    private void Flip()
    {
        //facingDirection *= -1;
       // alive.transform.Rotate(0.0f, 180.0f, 0.0f);
    }


    private IEnumerator ChangeTarget()
    {
        yield return new WaitForSeconds(2f);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(groundCheck.position, groundCheckDistance);
    }

    public void Damge()
    {
        Destroy(gameObject);
    }
}
