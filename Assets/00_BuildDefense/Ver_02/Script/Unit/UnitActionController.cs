using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionController : MonoBehaviour
{
    Unit selectedUnit;
    [SerializeField] Pathfinding pathfinding;

    public System.Action<bool> OnSelectedUnit;

    public void SetSelectedUnit(InteractableItem item)
    {
        if (selectedUnit == item) return;
        selectedUnit = (item is Unit) ? item as Unit : null;
        OnSelectedUnit?.Invoke(selectedUnit!=null); //set unit action panel
    }

    public void MoveAhead()
    {
        if (selectedUnit==null) return;
        selectedUnit.GetAction<MoveAction>().MoveAhead(pathfinding);
    }

    public void StopUnit()
    {
        if (selectedUnit==null) return; 
        selectedUnit.GetAction<MoveAction>().Cancel();
    }

    public void MoveUp()
    {
        if (selectedUnit==null) return;
        selectedUnit.GetAction<MoveAction>().MoveUp();
    }
}
