﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Enemy_controller : MonoBehaviour
{
    private enum State
    {
        Walking,
        Knockback,
        Dead
    }


    private State currentState;

    [SerializeField]
    private float
        groundCheckDistance,
        wallCheckDistance,
        movementSpeed;

    [SerializeField]
    private Transform
        groundCheck,
        wallCheck;

    [SerializeField]
    private LayerMask whatIsGround;

    private int facingDirection;

    private Vector2 movement;

    private bool
        groundDetected,
        wallDetected;

    private GameObject alive;
    private Rigidbody2D aliverb;

    private void Start()
    {
        alive = transform.Find("Alive").gameObject;
        aliverb = alive.GetComponent<Rigidbody2D>();

        facingDirection = 1;
    }

    private void Update()
    {
        switch(currentState)
        {
            case State.Walking:
                UpdateWalkingState();
                break;
            case State.Knockback:
                UpdateKnockbackState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;
        }
    }

    //walking state 

    private void EnterWalkingState()
    {

    }

    private void UpdateWalkingState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);

        if (!groundDetected || wallDetected)
        {
            ChangeTarget();
            Flip();
        }
        else
        {
            movement.Set(movementSpeed * facingDirection, aliverb.velocity.y);
            aliverb.velocity = movement;
        }
    }

    private void ExitWalkingState()
    {

    }


    //Knockback state 

    private void EnterKnockbackState()
    {

    }

    private void UpdateKnockbackState()
    {

    }
    private void ExitKnockbackState()
    {

    }


    //Dead state 

    private void EnterDeadState()
    {

    }

    private void UpdateDeadState()
    {

    }
    private void ExitDeadState()
    {

    }


    // other function ...................................



    private void Flip()
    {
        facingDirection *= -1;
        alive.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    private void SwitchState(State state)
    {
        switch(currentState)
        {
            case State.Walking:
               ExitWalkingState();
                break;
            case State.Knockback:
                ExitKnockbackState();
                break;
            case State.Dead:
                ExitDeadState();
                break;
        }

        switch (state)
        {
            case State.Walking:
               EnterWalkingState();
                break;
            case State.Knockback:
                EnterKnockbackState();
                break;
            case State.Dead:
                EnterDeadState();
                break;
        }
        currentState = state;
    }

    private IEnumerator ChangeTarget()
    {
        yield return new WaitForSeconds(200);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position,new Vector2(groundCheck.position.x , groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x, wallCheck.position.y));
    }
}