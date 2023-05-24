using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    GridPosition gridPosition;
    GridSystem gridSystem;
    List<Unit> unit;

    public Cell(GridPosition gridPosition, GridSystem gridSystem)
    {
        unit = new List<Unit>();
        this.gridPosition = gridPosition;
        this.gridSystem = gridSystem;
    }

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }

    public override string ToString()
    {
        string unitsName = " ";
        foreach(Unit a in unit)
        {
            unitsName += a+ "\n";
        }
        return gridPosition.ToString() + "\n" + unitsName;
    }
    public List<Unit> GetUnit()
    {
        return unit;
    }

    public void AddUnit(Unit unit)
    {
        this.unit.Add(unit);
    }
    public void RemoveUnit(Unit unit)
    {
        this.unit.Remove(unit);
    }

    public void ClearUnit()
    {
        this.unit = null;
    }
}
