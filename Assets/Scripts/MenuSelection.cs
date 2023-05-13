using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuSelection : MonoBehaviour
{
    private struct PriceType3D
    {
        public float price;
        public VehicleComponent type;
        public float colourPrice;
        public GameObject prefab;
        public Color baseColour;

        public PriceType3D(float price, VehicleComponent type, float colourPrice, GameObject prefab, Color baseColour){
            this.price = price;
            this.type = type;
            this.colourPrice = colourPrice;
            this.prefab = prefab;
            this.baseColour = baseColour;
        }
    }
    
    public static event Action<float, Color, VehicleComponent> OnNewSelection;

    float totalPrice;
    Dictionary<VehicleComponent,PriceType3D> selectionDict;
    PriceType3D pendingSelection;

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
        foreach(PriceType3D item in selectionDict.Values){
            totalPrice += item.price;
            totalPrice += item.colourPrice;
        }
    }
    // Checks to see if existing type exists in dict. If not it adds it. Else it overrites it.
    void OnComponentSelection(float price, float colourPrice, VehicleComponent type, GameObject prefab, Color baseColour)
    {
        if (selectionDict.ContainsKey(pendingSelection.type)){
            selectionDict[pendingSelection.type] = pendingSelection;
        } else {selectionDict.Add(pendingSelection.type, pendingSelection);}

        pendingSelection.price = price;
        pendingSelection.colourPrice = colourPrice;
        pendingSelection.type = type;
        pendingSelection.prefab = prefab;
        pendingSelection.baseColour = baseColour;
        OnNewSelection(colourPrice, baseColour, pendingSelection.type);
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


