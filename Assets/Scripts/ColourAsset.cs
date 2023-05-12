using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ColourAsset : MonoBehaviour
{
    public static event Action<float> OnColourUpdateEvent;

    [HideInInspector]
    public ComponentColourProperties data;

    [SerializeField]
    TextMeshProUGUI uiPrice;
    [SerializeField]
    Image uiImage;

    private float priceMod;
    private Color colour;
    private float price;

    void OnEnabled(){
        MenuSelection.OnNewSelection += OnNewSelection;
    }

    void Start(){
        priceMod = data.priceMod;
        colour = data.colour;
        uiImage = data.image;
    }

    void OnNewSelection(float colourPrice)
    {
        price = colourPrice * priceMod;
    }

    void OnClick(){
        OnColourUpdateEvent(price);
    }

    // Get event for base price of colour. Then update.
    
}
