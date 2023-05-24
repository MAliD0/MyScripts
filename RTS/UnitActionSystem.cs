using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] Unit unit;
    [SerializeField] bool isAvaib = true;
    [SerializeField] private LayerMask Unit;
    public event EventHandler OnChoose;
    public static UnitActionSystem instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ClearAvaib();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAvaib) return;
        if (Input.GetMouseButtonDown(0))
        {
            if (MakeShot1()) return;
            SetAvaib();
            Vector3 pos = MouseController.MakeShot().point;
            unit.GetMoveAction().StartAction(ClearAvaib,LevelGrid.instance.GetGridPos(pos));
        }
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            unit.GetTestAction().StartAction(ClearAvaib);
            SetAvaib();
        }
        
    }

    private void OnUnitSelect(Unit selectedUnit)
    {
        this.unit = selectedUnit;
        OnChoose?.Invoke(this, EventArgs.Empty);
    }

    public bool MakeShot1()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycast, float.MaxValue, Unit))
        {
            if (raycast.transform.TryGetComponent<Unit>(out Unit movement))
            {
                OnUnitSelect(movement);
                return true;
            }
        }
        return false;
    }

    public Unit getUnit()
    {
        return unit;
    }

    private void ClearAvaib()
    {
        isAvaib = true;
    }
    private void SetAvaib()
    {
        isAvaib = false;
    }
}
