using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellLay : MonoBehaviour
{
    [SerializeField] MeshRenderer renderer;
    void Start()
    {
        
    }

    public void Disable()
    {
        renderer.enabled = false;
    }
    public void Enable()
    {
        renderer.enabled = true;
    }
}
