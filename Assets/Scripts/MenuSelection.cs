using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    public static event Action<InventoryAsset> OnComponenetSelectionEvent;
    public static event Action OnColourUpdateEvent;

    float totalPrice;
    Dictionary<VehicleComponent,InventoryAsset> selectionDict;
    InventoryAsset pendingSelection;

    void Start()
    {
        OnComponenetSelectionEvent += OnComponentSelection;
        OnColourUpdateEvent += OnColourUpdate;
    }

    void UpdateSelection()
    {
        totalPrice = 0;
        foreach(InventoryAsset item in selectionDict.Values){
            totalPrice += item.data.componentPrice;
            totalPrice += item.data.colourPrice;
        }
    }

    void OnComponentSelection(InventoryAsset iasset)
    {
        pendingSelection = iasset;
        if (selectionDict.ContainsKey(pendingSelection.data.type)){
            selectionDict[pendingSelection.data.type] = pendingSelection;
        } else {selectionDict.Add(pendingSelection.data.type, pendingSelection);}
        UpdateSelection();
    }

    void OnColourUpdate()
    {
        // change colour of selection.
        // Update the price.
        UpdateSelection();
    }
}
