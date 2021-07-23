using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerDate",menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move state")]
    public float movementVelociry = 10f;


    [Header("Jump state")]
    public float jumpvelocity = 15f;
    public int amountOfJump = 1;


    [Header("InAir state")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMul = 0.5f;

    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3.0f;

    [Header("Wall Climb State")]
    public float WallClimbVelocity = 3f;

    [Header("Wall Jump  State")]
    public float WallJumpVelocity = 20;
    public float WallJumpTime = 0.4f;
    public Vector2 WallJumpAngle = new Vector2(1, 2);

    [Header("Ledge Climb State")]
    public Vector2 startOffset;
    public Vector2 stopOffset;

    [Header("Dash State")]
    public float dashcooldown = 0.5f;
    public float maxHoldTime = 1f;
    public float HoldTimeScale = 0.25f;
    public float DashTime = 0.2f;
    public float DashVelocity = 30f;
    public float Drag = 10f;
    public float DashEndYMultiplier = 0.2f;
    public float DistBetweenAfterImage = 0.5f;

    [Header("Crouch State")]
    public float crouchMovementVelocity = 5f;
    public float crouchColliderHeight = 0.8f;// so we fit in  1 block
    public float standColliderHeight = 1.8f;

}

