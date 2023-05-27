using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class A_Fly : MonoBehaviour
{
    [SerializeField] Vector2 posOfMouse;
    [SerializeField] Vector2 currentVel;
    [SerializeField] float maxSpeed;
    [SerializeField] float accele;


    Rigidbody2D rb;
    float x;
    float y;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void SetValue(InputAction.CallbackContext context)
    {
        posOfMouse = context.ReadValue<Vector2>();
    }

    public void FlyHandler()
    {
        Vector2 posFromCam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        x = Mathf.SmoothDamp(gameObject.transform.position.x, posFromCam.x, ref currentVel.x, accele, maxSpeed);
        y = Mathf.SmoothDamp(gameObject.transform.position.y, posFromCam.y, ref currentVel.y, accele, maxSpeed);
        rb.MovePosition(new Vector2(x, y));
    }
}
