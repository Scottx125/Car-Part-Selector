using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MenuSelection : MonoBehaviour
{
    public static event Action<float, Color, VehicleComponent> OnNewSelection;
    public static event Action RevealAdditionalComponenets;

    [SerializeField]
    private TextMeshProUGUI tmpPrice, tmpSpeed;
    [SerializeField]
    private string priceTextDefault = "£";
    [SerializeField]
    private string speedTextDefault = "MPH";

    private float totalPrice, totalSpeed;
    private bool isCarSelected = false;
    // Dict to hold the inventory of car parts selected.
    private Dictionary<VehicleComponent,PriceType3D> selectionDict = new Dictionary<VehicleComponent, PriceType3D>();
    private PriceType3D currentSelection;

    private void OnEnable(){
        InventoryAsset.OnComponenetSelectionEvent += OnComponentSelection;
        ColourAsset.OnColourUpdateEvent += OnColourUpdate;
    }

    private void OnDisable(){
        InventoryAsset.OnComponenetSelectionEvent -= OnComponentSelection;
        ColourAsset.OnColourUpdateEvent -= OnColourUpdate;
    }

    // Update prices.
    private void UpdateSelection()
    {
        totalPrice = 0;
        totalSpeed = 0;

        foreach(PriceType3D item in selectionDict.Values){
            totalPrice += item.price;
            totalPrice += item.colourPrice;
            totalSpeed += item.speed;
        }

        tmpPrice.text = $"Cost: {priceTextDefault}{totalPrice}";
        tmpSpeed.text = $"Max Speed: {totalSpeed} {speedTextDefault}";
    }
    // Checks to see if existing type exists in dict. If not it adds it. Else it overrites it.
    private void OnComponentSelection(float price, float colourPrice, VehicleComponent type, GameObject prefab, Color baseColour, float speed)
    {
        if (isCarSelected == false)
        {
            isCarSelected = true;
            RevealAdditionalComponenets();
        }
        // If the obj is already in selection.
        if (currentSelection.prefab == prefab)
        {
            return;
        }

        OverwriteCurrentSelection(price, colourPrice, type, prefab, baseColour, speed);
        // Add/overide object in the dictionary.
        selectionDict.Add(currentSelection.type, currentSelection);

        // Activates the new obj.
        GetMaterialsAndChangeColour(currentSelection.baseColour);
        ActivateDeactevateObj(currentSelection.prefab);

        OnNewSelection(colourPrice, baseColour, currentSelection.type);
        UpdateSelection();
    }

    private void OverwriteCurrentSelection(float price, float colourPrice, VehicleComponent type, GameObject prefab, Color baseColour, float speed)
    {
        // Handles overriting old object in dict.
        currentSelection.price = price;
        currentSelection.colourPrice = colourPrice;
        currentSelection.type = type;
        currentSelection.prefab = prefab;
        currentSelection.baseColour = baseColour;
        currentSelection.speed = speed;
    }

    // Updates the colour price of the current pending selection.
    private void OnColourUpdate(float colourPrice, Color colour)
    {
        currentSelection.colourPrice = colourPrice;
        GetMaterialsAndChangeColour(colour);
        selectionDict[currentSelection.type] = currentSelection;
        UpdateSelection();
    }
    // LOOK INTO THIS NEXT MEETING.
    private void GetMaterialsAndChangeColour(Color colour){
        // VERY EXPENSIVE
        Renderer[] matInChildren = currentSelection.prefab.GetComponentsInChildren<Renderer>();
        foreach (Renderer item in matInChildren){
            item.material.color = colour;
        }
    }

    private void ActivateDeactevateObj(GameObject obj)
    {
        obj.SetActive(!obj.activeInHierarchy);
    }
}

    public struct PriceType3D
    {
        public float price;
        public VehicleComponent type;
        public float colourPrice;
        public GameObject prefab;
        public Color baseColour;
        public float speed;

        public PriceType3D(float price, VehicleComponent type, float colourPrice, GameObject prefab, Color baseColour, float speed){
            this.price = price;
            this.type = type;
            this.colourPrice = colourPrice;
            this.prefab = prefab;
            this.baseColour = baseColour;
            this.speed = speed;
        }
    }


