using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{

    #region Check transform

    public Transform GroundCheck
    {
        get
        {
            if (groundCheck)
                return groundCheck;

            Debug.LogError("No Ground Check on " + core.transform.parent.name);
            return null;

        }
        private set => groundCheck = value;
    }
    public Transform WallCheck
    {
        get
        {
            if (wallCheck)
                return wallCheck;

            Debug.LogError("No Wall Check on " + core.transform.parent.name);
            return null;

        }
        private set => wallCheck = value;
    }
    public Transform LedgeCheckHorizontal
    {
        get
        {
            if (ledgeCheckHorizontal)
                return ledgeCheckHorizontal;

            Debug.LogError("No Ledge Check Horizontal on " + core.transform.parent.name);
            return null;

        }
        private set => ledgeCheckHorizontal = value;
    }
    public Transform LedgeCheckVertical
    {
        get
        {
            if (ledgeCheckVertical)
                return ledgeCheckVertical;

            Debug.LogError("No Ledge Check Vertical on " + core.transform.parent.name);
            return null;

        }
        private set => ledgeCheckVertical = value;
    }
    public Transform CeilingCheck
    {
        get
        {
            if (ceilingCheck)
                return ceilingCheck;

            Debug.LogError("No Ceiling Check on " + core.transform.parent.name);
            return null;

        }
        private set => ceilingCheck = value;
    }
    public float GroundCheckRadius { get => groundCheckRadius; set => groundCheckRadius = value; }
    public float WallCheckDistance { get => wallCheckDistance; set => wallCheckDistance = value; }
    public LayerMask WhatIsGround { get => whatIsGround; set => whatIsGround = value; }

    [SerializeField] private Transform groundCheck = default;
    [SerializeField] private Transform wallCheck = default;
    [SerializeField] private Transform ledgeCheckHorizontal = default;
    [SerializeField] private Transform ledgeCheckVertical = default;

    [SerializeField] private Transform ceilingCheck = default;


    [SerializeField] private float groundCheckRadius = default;
    [SerializeField] private float wallCheckDistance = default;

    [SerializeField] private LayerMask whatIsGround = default;

    #endregion

    #region Check fun


    public bool Ground
    {
        get => Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);
    }

    public bool Ceiling
    {
        get => Physics2D.OverlapCircle(CeilingCheck.position, groundCheckRadius, whatIsGround);
    }

    public bool WallFront
    {
        get => Physics2D.Raycast(WallCheck.position, Vector2.right * core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }

    public bool WallBack
    {
        get => Physics2D.Raycast(WallCheck.position, Vector2.right * -core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }

    public bool LedgeHorizontal
    {
        get => Physics2D.Raycast(LedgeCheckHorizontal.position, Vector2.right * core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }
    public bool LedgeVertical
    {
        get => Physics2D.Raycast(LedgeCheckVertical.position, Vector2.down, wallCheckDistance, whatIsGround);
    }




    #endregion
}
