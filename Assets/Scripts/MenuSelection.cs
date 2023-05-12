using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuSelection : MonoBehaviour
{
    private struct PriceType
    {
        public float price;
        public VehicleComponent type;
        public float colourPrice;

        public PriceType(float price, VehicleComponent type, float colourPrice){
            this.price = price;
            this.type = type;
            this.colourPrice = colourPrice;
        }
    }
    
    public static event Action<float> OnNewSelection;

    float totalPrice;
    Dictionary<VehicleComponent,PriceType> selectionDict;
    PriceType pendingSelection;

    void OnEnabled(){
        InventoryAsset.OnComponenetSelectionEvent += OnComponentSelection;
        ColourAsset.OnColourUpdateEvent += OnColourUpdate;
    }
    void OnDisabled(){
        InventoryAsset.OnComponenetSelectionEvent -= OnComponentSelection;
        ColourAsset.OnColourUpdateEvent -= OnColourUpdate;
    }
    void Start()
    { 

    }
    // Update prices.
    void UpdateSelection()
    {
        totalPrice = 0;
        foreach(PriceType item in selectionDict.Values){
            totalPrice += item.price;
            totalPrice += item.colourPrice;
        }
    }
    // Checks to see if existing type exists in dict. If not it adds it. Else it overrites it.
    void OnComponentSelection(float price, float colourPrice, VehicleComponent type)
    {
        pendingSelection.price = price;
        pendingSelection.colourPrice = colourPrice;
        pendingSelection.type = type;
        if (selectionDict.ContainsKey(pendingSelection.type)){
            selectionDict[pendingSelection.type] = pendingSelection;
        } else {selectionDict.Add(pendingSelection.type, pendingSelection);}
        OnNewSelection(colourPrice);
        UpdateSelection();
    }
    // Updates the colour price of the current pending selection.
    void OnColourUpdate(float colourPrice)
    {
        pendingSelection.colourPrice = colourPrice;
        selectionDict[pendingSelection.type] = pendingSelection;
        UpdateSelection();
    }
}


