using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitActionBase : MonoBehaviour
{
    protected Unit unit;
    protected Action onInteractionEnd;
    protected bool IsTriggered;
    public abstract string actionName();
    protected virtual void Awake()
    {
        unit = GetComponent<Unit>();
    }

    protected virtual void Disable()
    {
        IsTriggered = false;
    }
    protected virtual void Enable()
    {
        IsTriggered = true;
    }
}
