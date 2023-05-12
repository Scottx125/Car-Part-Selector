using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryAsset : MonoBehaviour
{
    public VehiclePropertyScriptableObject data {private get; set; }

    [SerializeField]
    TextMeshProUGUI uiPrice;
    [SerializeField]
    TextMeshProUGUI uiItemName;
    [SerializeField]
    Image uiImage;

    float price;
    Color colour;

    void Start(){
        price = data.price;
        colour = data.defaultColour;
        if (data.image != null){uiImage = data.image;}
        uiItemName.text = data.itemName;
        uiPrice.text = data.price.ToString();
    }
}
