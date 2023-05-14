using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ColourAsset : MonoBehaviour
{
    public static event Action<float, Color> OnColourUpdateEvent;

    [HideInInspector]
    public ComponentColourProperties data;

    [SerializeField]
    TextMeshProUGUI uiPrice;
    [SerializeField]
    Image uiImage;

    private float priceMod;
    private Color colour;
    private float price;
    private VehicleComponent type;

    void Start(){
        colour = data.colour;
        uiImage.sprite = data.image;
        uiImage.color = colour;
        uiPrice.text = "£0";
    }

    public void DefaultColourUpdate(Color baseColour)
    {
        colour = baseColour;
        uiImage.color = baseColour;
    }

    public void UpdateStats(float colourPrice, VehicleComponent type){
        int index = data.typePriceModList.FindIndex(x => x.type == type);
        priceMod = data.typePriceModList[index].priceMod;
        price = colourPrice * priceMod;
        uiPrice.text = "£" + price;
    }

    public void OnClick(){
        if (price == 0){return;}
        OnColourUpdateEvent(price, colour);
    }

    // Get event for base price of colour. Then update.
    
}
