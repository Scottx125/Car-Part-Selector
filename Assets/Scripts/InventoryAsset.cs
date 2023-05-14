using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryAsset : MonoBehaviour
{
    public static event Action<float, float, VehicleComponent, GameObject, Color> OnComponenetSelectionEvent;

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

    void Start(){
        price = data.componentPrice;
        colourPrice = data.colourPrice;
        uiPrice.text = "£" + data.componentPrice;
        uiImage.sprite = data.image;
        uiItemName.text = data.itemName;
        componentType = data.type;
        prefab = data.worldGameObj;
        baseColour = data.defaultColour;

        prefab = Instantiate(prefab);
        prefab.GetComponent<Renderer>().material.color = baseColour;
        prefab.SetActive(false);
    }

    public void OnClick()
    {
        OnComponenetSelectionEvent(price, colourPrice, componentType, prefab, baseColour);
    }
}
