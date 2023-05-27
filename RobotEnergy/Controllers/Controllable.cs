using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllable : MonoBehaviour
{
    public bool isActive;


    public virtual void Enable(bool tf)
    {
        isActive = tf;
    }

    public virtual bool Swap(bool tf)
    {
        Enable(tf);
        return true;
    }
}
