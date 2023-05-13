using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu(fileName = "ComponentColourProperties", menuName = "ScriptableObjects/ComponentColourProperties", order = 2)]
public class ComponentColourProperties : ScriptableObject
{   
    [Serializable]
    public struct TypePriceMod
    {
        public VehicleComponent type;
        public float priceMod;
    }

    public List<TypePriceMod> typePriceModList;
    public Color colour;
    public Image image;
}
