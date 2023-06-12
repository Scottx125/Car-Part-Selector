using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu(fileName = "ComponentColourProperties", menuName = "ScriptableObjects/ComponentColourProperties", order = 2)]
public class ComponentColourProperties : ScriptableObject
{   

    public List<TypePriceMod> getTypePriceModList => typePriceModList;
    public Color getColour => colour;
    public Sprite getImage => image;
    public bool getIsDefaultColour => isDefaultColour;

    [Serializable]
    public struct TypePriceMod
    {
        public VehicleComponent getType => type;
        public float getPriceMod => priceMod;

        [SerializeField]
        private VehicleComponent type;
        [SerializeField]
        private float priceMod;
    }
    [SerializeField]
    private List<TypePriceMod> typePriceModList;
    [SerializeField]
    private Color colour;
    [SerializeField]
    private Sprite image;
    [SerializeField]
    private bool isDefaultColour;
    
    
}
