using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private HexGridSystem<PathNode> gridSystem;
    private GridPosition gridPosition;
    public GridPosition GridPos => gridPosition;
    private int fCost;
    private int gCost;
    private int hCost;

    public int FCost => fCost;
    public int GCost => gCost;
    public int HCost => hCost;

    private PathNode cameFromNode;
    public PathNode CameFromNode => cameFromNode;

    private IGameItem item;

    public PathNode(HexGridSystem<PathNode> gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
    }

    public override string ToString()
    {
        return gridPosition.ToString();
    }

    public void SetGCost(int gCost)
    {
        this.gCost = gCost;
    }

    public void SetHCost(int hCost)
    {
        this.hCost = hCost;
    }

    public void SetCameFromNode(PathNode cameFromNode)
    {
        this.cameFromNode = cameFromNode;
    }

    public int CalculateFCost()
    {
        return fCost = hCost + gCost;
    }

    public void SetItem(IGameItem item)
    {
        this.item = item;
    }

    public bool IsWalkable()
    {
        return item==null;
    }
}
