using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MenuSelection : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tmpPrice;

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
    PriceType3D currentSelection;

    void OnEnabled(){
        InventoryAsset.OnComponenetSelectionEvent += OnComponentSelection;
        ColourAsset.OnColourUpdateEvent += OnColourUpdate;
    }
    void OnDisabled(){
        InventoryAsset.OnComponenetSelectionEvent -= OnComponentSelection;
        ColourAsset.OnColourUpdateEvent -= OnColourUpdate;
    }
    // Update prices.
    void UpdateSelection()
    {
        totalPrice = 0;
        foreach(PriceType3D item in selectionDict.Values){
            totalPrice += item.price;
            totalPrice += item.colourPrice;
        }
        tmpPrice.text = "£" + totalPrice;
    }
    // Checks to see if existing type exists in dict. If not it adds it. Else it overrites it.
    void OnComponentSelection(float price, float colourPrice, VehicleComponent type, GameObject prefab, Color baseColour)
    {
        if (currentSelection.type == type){
            currentSelection.prefab.GetComponent<Material>().color = currentSelection.baseColour;
            ActivateDeactevateObj();
        }

        currentSelection.price = price;
        currentSelection.colourPrice = colourPrice;
        currentSelection.type = type;
        currentSelection.prefab = prefab;
        currentSelection.baseColour = baseColour;

        if (selectionDict.ContainsKey(type)){
            selectionDict[currentSelection.type] = currentSelection;
        } else {selectionDict.Add(currentSelection.type, currentSelection);}

        ActivateDeactevateObj();
        OnNewSelection(colourPrice, baseColour, currentSelection.type);
        UpdateSelection();
    }
    // Updates the colour price of the current pending selection.
    void OnColourUpdate(float colourPrice, Color colour)
    {
        currentSelection.colourPrice = colourPrice;
        currentSelection.prefab.GetComponent<Material>().color = colour;
        selectionDict[currentSelection.type] = currentSelection;
        UpdateSelection();
    }

    void ActivateDeactevateObj()
    {
        currentSelection.prefab.SetActive(!currentSelection.prefab.activeInHierarchy);
    }
}


