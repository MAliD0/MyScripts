using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTestAction : UnitActionBase
{
    [SerializeField] bool isDancing = false;
    [SerializeField]Animator animator;
    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTriggered) 
        {
            animator.SetBool("IsDancing", isDancing);
            if(Time.deltaTime > 5)
            {
                base.Disable();
                onInteractionEnd();
                isDancing = false;
            }
        }
    }

    public void StartAction(Action onInteractionEnd)
    {
        this.onInteractionEnd = onInteractionEnd;
        isDancing = true;
        base.Enable();
    }

    public override string actionName()
    {
        return "Dance";
    }
}
