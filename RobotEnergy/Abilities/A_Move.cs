using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.InputSystem;

public class A_Move : MonoBehaviour
{
    [Header("Data")]
    public float acceleration;
    public float deceleration;
    public float speed;

    [Header("Raw input")]
    Vector2 movementDirection;
    public float horizontal { get; private set; }
    float vertical;

    public bool isMoving { get; private set; }

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetValues(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
        horizontal = movementDirection.x;
        vertical = movementDirection.y;
        isMoving = horizontal != 0 || vertical != 0;
    }

    public void MovementHandler()
    {
        rb.velocity = new Vector2(Mathf.MoveTowards(rb.velocity.x, 0, deceleration), rb.velocity.y);
        if (isMoving)
        {
            rb.velocity = new Vector2(Mathf.MoveTowards(rb.velocity.x, horizontal* speed, acceleration), rb.velocity.y);
        }
        else
            rb.velocity = new Vector2(Mathf.MoveTowards(rb.velocity.x, 0, deceleration), rb.velocity.y);
    }

}
