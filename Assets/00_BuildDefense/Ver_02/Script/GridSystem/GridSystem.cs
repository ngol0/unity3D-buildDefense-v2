using System;
using UnityEngine;

public class GridSystem<TGridItem>
{
    private int gridHeight;
    private int gridWidth;
    private int cellSize;
    private TGridItem[,] gridItemArray;

    public GridSystem(int gridWidth, int gridHeight, int cellSize, Func<GridSystem<TGridItem>, GridPosition, TGridItem> createGridItem)
    {
        this.gridWidth = gridWidth;
        this.gridHeight = gridHeight;
        this.cellSize = cellSize;

        gridItemArray = new TGridItem[gridWidth, gridHeight];
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                GridPosition gridPos = new(x,z);

                //create grid array data
                gridItemArray[x,z] = createGridItem(this, gridPos);

            }
        }
    }

    public void CreateGridUI(GridItemUI gridItemPrefab, Transform root)
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                GridPosition gridPos = new(x,z);

                //create grid ui
                GridItemUI gridItemUI = 
                    GameObject.Instantiate<GridItemUI>(gridItemPrefab, GetWorldPosition(gridPos), Quaternion.identity, root);
                gridItemUI.SetGridItem(GetGridItem(gridPos));
            }
        }
    }

    public TGridItem GetGridItem(GridPosition gridPos)
    {
        return gridItemArray[gridPos.x, gridPos.z];
    }

    public Vector3 GetWorldPosition(GridPosition gridPos)
    {
        return new Vector3(gridPos.x, 0, gridPos.z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPos)
    {
        return new GridPosition(
            Mathf.RoundToInt(worldPos.x/cellSize), 
            Mathf.RoundToInt(worldPos.z/cellSize)
        );
    }

    public bool IsValidGridPos(GridPosition gridPos)
    {
        return 0 <= gridPos.x 
            && gridPos.x <= gridWidth-1     
            && 0 <= gridPos.z 
            && gridPos.z <= gridHeight-1;
    }
}