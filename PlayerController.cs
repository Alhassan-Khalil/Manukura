using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float speed, jumpSpeed;

    private PlayerActionControls playerActionControls;
    private Rigidbody2D rb;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public bool IsGrounded;
    public LayerMask whatIsGrounded;


    // awake run before start
    private void Awake()
    {
        playerActionControls = new PlayerActionControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        playerActionControls.land_movement.Jump.performed += _ => Jump();
    }
    private void Jump()
    {
        if (IsGrounded)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            //or
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {

        IsGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGrounded);
        //Read the movment value 
        float movementInput = playerActionControls.land_movement.move.ReadValue<float>();

        //move the player
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;
    }





}
