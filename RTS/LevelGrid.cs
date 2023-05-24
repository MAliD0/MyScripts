using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] GridSystem gridSystem;
    [SerializeField] Transform cellInfoPrefab;
    public static LevelGrid instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gridSystem = new GridSystem(15, 15);
        for (int i = 0; i < gridSystem.GetWidth(); i++)
        {
            for (int z = 0; z < gridSystem.GetHeight(); z++)
            {
                Transform cellDebug = Instantiate(cellInfoPrefab, gridSystem.GetWorldPos(new GridPosition( i, z)), Quaternion.identity, this.transform);
                cellDebug.GetComponent<DebugCell>().SetInfo(gridSystem.GetCell(new GridPosition(i, z)));
            }
        }
    }

    public void AddUnitAtCell(GridPosition position, Unit unit)
    {
        gridSystem.GetCell(position).AddUnit(unit);
    }
    public void ClearUnitAtCell(GridPosition position, Unit unit)
    {
        gridSystem.GetCell(position).RemoveUnit(unit);
    }
    public List<Unit> GetUnitAtCell(GridPosition position)
    {
        return gridSystem.GetCell(position).GetUnit();
    }

    public void ChangeUnitPosAtCell(GridPosition prevPos, GridPosition newPos, Unit unit)
    {
        ClearUnitAtCell(prevPos, unit);
        AddUnitAtCell(newPos, unit);
    }

    public GridPosition GetGridPos(Vector3 pos)
    {
        return new GridPosition(Mathf.RoundToInt(pos.x / gridSystem.GetSize()), Mathf.RoundToInt(pos.z / gridSystem.GetSize()));
    }
    public Vector3 GetWorldPos(Vector3 pos)
    {
        return gridSystem.GetWorldPos(new GridPosition((int)pos.x, (int)pos.z));
    }
    public bool CanBeAccessed(GridPosition gridPosition)
    {
        return gridSystem.CanBeAccessed(gridPosition);
    }

    public int GetWigth()
    {
        return gridSystem.GetWidth();
    }
    public int GetHeight()
    {
        return gridSystem.GetHeight();
    }
}
