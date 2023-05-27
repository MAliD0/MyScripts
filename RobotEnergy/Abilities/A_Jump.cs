using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Jump : MonoBehaviour
{
    Rigidbody2D rb;

    public bool isJumping{ get; private set; }
    public bool isJumpPressed;
    public bool isGrounded { get; private set; }

    [SerializeField] private LayerMask ground;
    public float groundRad;
    public Vector2 groundPos;

    public float maxJumpHeight = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void HandleJump()
    {
        if (isJumpPressed && isGrounded & !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxJumpHeight);
            isJumping = true;
        }
        else if (!isJumpPressed && isGrounded & isJumping)
        {
            isJumping = false;
        }
    }
    public void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(new Vector3(transform.position.x + groundPos.x, transform.position.y + groundPos.y, 0), groundRad, ground);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(new Vector3(transform.position.x + groundPos.x, transform.position.y + groundPos.y, 0), groundRad);
    }

}
