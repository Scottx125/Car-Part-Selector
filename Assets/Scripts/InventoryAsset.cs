using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryAsset : MonoBehaviour
{
    public static event Action<float, float, VehicleComponent, GameObject, Color, float> OnComponenetSelectionEvent;

    [HideInInspector]
    public VehicleComponentProperties data;

    [SerializeField]
    private TextMeshProUGUI uiPrice, uiItemName;
    [SerializeField]
    private Image uiImage;

    private float price, colourPrice, speed;
    private VehicleComponent componentType;
    private GameObject prefab;
    private Color baseColour;

    public void Setup(){
        price = data.getComponentPrice;
        colourPrice = data.getColourPrice;
        uiPrice.text = "£" + price;
        uiImage.sprite = data.getImage;
        uiItemName.text = data.getItemName;
        componentType = data.getVehicleCompType;
        prefab = data.getWorldGameObj;
        baseColour = data.getDefaultColour;
        speed = data.getSpeed;

        prefab = Instantiate(prefab);
        Renderer[] matInChildren = prefab.GetComponentsInChildren<Renderer>();
        foreach(Renderer item in matInChildren){
            item.material.color = baseColour;
        }
        prefab.SetActive(false);
    }

    public void OnClick()
    {
        OnComponenetSelectionEvent(price, colourPrice, componentType, prefab, baseColour, speed);
    }
}
