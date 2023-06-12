using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MenuSelection : MonoBehaviour
{
    public static event Action<float, Color, VehicleComponent> OnNewSelection;
    public static event Action FirstSelection;

    [SerializeField]
    private TextMeshProUGUI tmpPrice, tmpSpeed;

    private struct PriceType3D
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

    private float totalPrice, totalSpeed;
    private bool firstSelection = false;
    private Dictionary<VehicleComponent,PriceType3D> selectionDict = new Dictionary<VehicleComponent, PriceType3D>();
    private PriceType3D currentSelection = new PriceType3D(0f, VehicleComponent.None, 0f, null, Color.clear, 0f);

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
        tmpPrice.text = "Cost: £" + totalPrice;
        tmpSpeed.text = "Max Speed: " + totalSpeed + " MPH";
    }
    // Checks to see if existing type exists in dict. If not it adds it. Else it overrites it.
    private void OnComponentSelection(float price, float colourPrice, VehicleComponent type, GameObject prefab, Color baseColour, float speed)
    {
        if (firstSelection == false){
            firstSelection = true;
            FirstSelection();
        }
        // If the obj is already in selection.
        if (currentSelection.prefab == prefab){
            return;
        }

        // Handles overriting old object in dict.
        currentSelection.price = price;
        currentSelection.colourPrice = colourPrice;
        currentSelection.type = type;
        currentSelection.prefab = prefab;
        currentSelection.baseColour = baseColour;
        currentSelection.speed = speed;

        // Check to see if the type exists already. If it does deactivate the old object and overwrite.
        // If it doens't, add it.
        if (selectionDict.ContainsKey(type)){
            GetMaterialsAndChangeColour(selectionDict[type].baseColour);
            ActivateDeactevateObj(selectionDict[type].prefab);
            selectionDict[currentSelection.type] = currentSelection;
        } else {selectionDict.Add(currentSelection.type, currentSelection);}
        // Activates the new obj.
        GetMaterialsAndChangeColour(currentSelection.baseColour);
        ActivateDeactevateObj(currentSelection.prefab);
        
        OnNewSelection(colourPrice, baseColour, currentSelection.type);
        UpdateSelection();
    }
    // Updates the colour price of the current pending selection.
    private void OnColourUpdate(float colourPrice, Color colour)
    {
        currentSelection.colourPrice = colourPrice;
        GetMaterialsAndChangeColour(colour);
        selectionDict[currentSelection.type] = currentSelection;
        UpdateSelection();
    }

    private void GetMaterialsAndChangeColour(Color colour){
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


