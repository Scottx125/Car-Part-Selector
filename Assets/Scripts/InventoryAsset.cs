using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryAsset : MonoBehaviour
{
    public VehiclePropertyScriptableObject data;

    [SerializeField]
    TextMeshProUGUI uiPrice;
    [SerializeField]
    TextMeshProUGUI uiItemName;
    [SerializeField]
    Image uiImage;

    private float price;

    void Start(){
        price = data.componentPrice;
        if (data.image != null){uiImage = data.image;}
        uiItemName.text = data.itemName;
        uiPrice.text = data.componentPrice.ToString();
    }
}
