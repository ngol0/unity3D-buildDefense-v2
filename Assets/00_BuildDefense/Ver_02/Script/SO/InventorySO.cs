using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/InventorySO")]
public class InventorySO : ScriptableObject
{
    const int MAX_SLOTS = 9;
    public List<InteractableData> interactableItemList;

    public void AddToInteractableList(InteractableData item, Action<InteractableData> UpdateUI)
    {
        if (interactableItemList.Count == MAX_SLOTS) return;
        interactableItemList.Add(item);

        UpdateUI(item);
    }

    public void RemoveInteractableItem(InteractableData item)
    {
        interactableItemList.Remove(item);
        Debug.Log(":::Inventory Remove: " + item.name);
    }
}
