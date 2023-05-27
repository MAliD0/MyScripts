using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RobotController : Controllable
{

    A_Move Move;
    A_Jump Jump;
    A_Rotate Rotate;
    A_Interact Interact;

    void Awake()
    {
        Move = GetComponent<A_Move>();
        Jump = GetComponent<A_Jump>();
        Rotate = GetComponent<A_Rotate>();
        Interact = GetComponent<A_Interact>();
    }
    
    private void Start()
    {
        InputManager.instance.inputActions.Move.Move.started += Move.SetValues;
        InputManager.instance.inputActions.Move.Move.canceled += Move.SetValues;

        InputManager.instance.inputActions.Move.Jump.started += i => Jump.isJumpPressed = i.ReadValueAsButton();
        InputManager.instance.inputActions.Move.Jump.canceled += i => Jump.isJumpPressed = i.ReadValueAsButton();

        InputManager.instance.inputActions.Move.Interact.started += Interact.Interact;
    }
    private new void Update()
    {
        if (!isActive) return;
            Rotate.HangleRotation(Move.isMoving, Move.horizontal);
    }

    private new void FixedUpdate()
    {
        if (!isActive) return;
        Jump.GroundCheck();
        Move.MovementHandler();
        Jump.HandleJump();
        
    }

    public override void Enable(bool tf)
    {
        base.Enable(tf);
    }

    public override bool Swap(bool tf)
    {
        if(PlayerManager.instance.controllables.Count > 1)
        {
            Enable(tf);
            return true;
        }
        return false;
    }
}
