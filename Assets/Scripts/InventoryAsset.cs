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
    TextMeshProUGUI uiPrice;
    [SerializeField]
    TextMeshProUGUI uiItemName;
    [SerializeField]
    Image uiImage;

    private float price;
    private float colourPrice;
    private VehicleComponent componentType;
    private GameObject prefab;
    private Color baseColour;
    private float speed;

    void Start(){
        price = data.componentPrice;
        colourPrice = data.colourPrice;
        uiPrice.text = "£" + data.componentPrice;
        uiImage.sprite = data.image;
        uiItemName.text = data.itemName;
        componentType = data.type;
        prefab = data.worldGameObj;
        baseColour = data.defaultColour;
        speed = data.speed;

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
