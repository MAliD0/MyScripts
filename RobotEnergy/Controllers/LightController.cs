using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : Controllable
{
    A_Fly Fly;
    A_Interact Interact;

    public LayerMask player;

    private void Awake()
    {
        Fly = GetComponent<A_Fly>();
        Interact = GetComponent<A_Interact>();
    }
    private void Start()
    {
        InputManager.instance.inputActions.Move.Mouse.performed += Fly.SetValue;
        InputManager.instance.inputActions.Move.Interact.started += Interact.Interact;
    }

    private void Update()
    {
        if (!isActive) return;
    }
    private void FixedUpdate()
    {
        if (!isActive) return;
        Fly.FlyHandler();
    }

    public override void Enable(bool tf)
    {
        base.Enable(tf);
    }

    public override bool Swap(bool tf)
    {
        if (tf)
        {
            Enable(true);
            OnSwap();
            return true;
        }
        else
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, Interact.radius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.tag == "Player" && collider.transform != this.transform)
                {
                    print("enter swap");
                    Enable(tf);
                    OnSwap();
                    return true;
                }
            }
        }
        print("exit swap");
        return false;
    }

    public void OnSwap()
    {
        if(isActive == false)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.transform.position = PlayerManager.instance.controllables[PlayerManager.instance.lastIndex].transform.position;
        }
    }
}
