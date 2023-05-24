using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class GridUI : MonoBehaviour
{
    [SerializeField] Transform cellLayPrefab;
    [SerializeField] CellLay[,] cellLays;
    [SerializeField] Unit unit;
    int wigth, height;
    public static GridUI instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        wigth = LevelGrid.instance.GetWigth();
        height = LevelGrid.instance.GetHeight();
        cellLays = new CellLay[wigth, height];
        for (int i = 0; i < wigth; i++)
        {
            for (int z = 0; z < height; z++)
            {
                Transform lay = Instantiate(cellLayPrefab, LevelGrid.instance.GetWorldPos(new Vector3(i, 0, z)), Quaternion.identity, transform);
                cellLays[i, z] = lay.GetComponent<CellLay>();
                lay.GetComponent<CellLay>().Disable();
            }
        }
    }
    private void Update()
    {
        GridUI.instance.HideElements();
        GridUI.instance.ShowElements(UnitActionSystem.instance.getUnit().GetMoveAction().FindValidCells());
    }
    public void ShowElements(List<GridPosition> positions)
    {
        foreach (GridPosition item in positions)
        {
            GetLay(item).GetComponent<CellLay>().Enable();
        }
    }
    public void HideElements()
    {
        for (int i = 0; i < wigth; i++)
        {
            for (int z = 0; z < height; z++)
            {

                cellLays[i,z].GetComponent<CellLay>().Disable();
            }
        }
    }

    public CellLay GetLay(GridPosition position)
    {
        return cellLays[position.getX(), position.getZ()];
    }


}
