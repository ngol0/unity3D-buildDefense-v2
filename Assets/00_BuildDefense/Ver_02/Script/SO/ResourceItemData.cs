using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InteractableData/ResourceItem")]
public class ResourceItemData : InteractableData
{
    public ResourceGeneratorData resourceData; //number of resource to build tower
    public int healthAmountMax;

    public string GetTowerResourceInfo()
    {
        string str = "";
        foreach (var resource in resourceCostToBuild)
        {
            str += "<color=#" + resource.resourceType.colorHex + ">" + "\n" +
            resource.resourceType.shortName + ": " + resource.amount;
        }
        return str;
    }

    public InteractableData[] itemToSell;
}
