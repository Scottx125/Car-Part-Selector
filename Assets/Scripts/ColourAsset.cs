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
    private TextMeshProUGUI uiPrice;
    [SerializeField]
    private Image uiImage;

    private float priceMod;
    private Color colour;
    private float price;
    private VehicleComponent type;

    public void Setup(){
        colour = data.getColour;
        uiImage.sprite = data.getImage;
        uiImage.color = colour;
        uiPrice.text = "£0";
    }

    public void DefaultColourUpdate(Color baseColour)
    {
        colour = baseColour;
        uiImage.color = baseColour;
    }

    public void UpdateStats(float colourPrice, VehicleComponent type){
        int index = data.getTypePriceModList.FindIndex(x => x.getType == type);
        priceMod = data.getTypePriceModList[index].getPriceMod;
        price = colourPrice * priceMod;
        uiPrice.text = "£" + price;
    }

    public void OnClick(){
        if (price == 0){return;}
        OnColourUpdateEvent(price, colour);
    }

    // Get event for base price of colour. Then update.
    
}
