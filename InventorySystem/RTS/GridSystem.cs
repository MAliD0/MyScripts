using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UIElements;
[Serializable]
public class GridSystem 
{
    private int width;
    int height;
    int cellSize = 2;
    private Cell[,] cells;

    public GridSystem(int width, int height)
    {
        this.width = width;
        this.height = height;
        cells = new Cell[width, height];
        GridInit();
    }

    private void GridInit()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                Cell cell = new Cell(gridPosition, this);
                cells[x, z] = cell;
                Debug.DrawLine(GetWorldPos(gridPosition), GetWorldPos(gridPosition) + Vector3.right * 0.2f, Color.cyan, 1000);
            }
        }
    }

    public Vector3 GetWorldPos(GridPosition position)
    {
        return new Vector3(position.getX(), 0, position.getZ()) * cellSize;
    }

    public GridPosition GetGridPos(Vector3 pos)
    {
        return new GridPosition(Mathf.RoundToInt( pos.x/cellSize), Mathf.RoundToInt(pos.z / cellSize));
    }
    
    public bool CanBeAccessed(GridPosition gridPosition)
    {
        if((gridPosition.getX() < width && gridPosition.getX() >= 0) && (gridPosition.getZ() < height && gridPosition.getZ() >= 0))
        {
            return true;
        }
        return false;
    }
    
    
    public Cell GetCell(GridPosition pos)
    {
        return cells[pos.getX(), pos.getZ()];
    }
    public Cell[,] GetCells()
    {
        return cells;
    }
    public int GetWidth()
    {
        return width;
    }
    public int GetHeight()
    {
        return height;
    }
    public int GetSize()
    {
        return cellSize;
    }
}
