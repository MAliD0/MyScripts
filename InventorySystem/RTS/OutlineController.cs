using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    [SerializeField] Unit unit;
    MeshRenderer mesh;
    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        UnitActionSystem.instance.OnChoose += ChangeValue;
        UpdateVisuals();
    }

    private void ChangeValue(object @object, EventArgs emty)
    {
        UpdateVisuals();
    }

    private void UpdateVisuals() {
        if (UnitActionSystem.instance.getUnit() == unit) mesh.enabled = true;

        else
        {
            mesh.enabled = false;
        }
    }

}
