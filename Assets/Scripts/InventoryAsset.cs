using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryAsset : MonoBehaviour
{
    public static event Action<float, float, VehicleComponent> OnComponenetSelectionEvent;

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

    void Start(){
        price = data.componentPrice;
        colourPrice = data.colourPrice;
        uiPrice.text = data.componentPrice.ToString();
        uiImage = data.image;
        uiItemName.text = data.itemName;
        componentType = data.type;
    }

    void OnClick()
    {
        OnComponenetSelectionEvent(price,colourPrice,componentType);
    }
}
