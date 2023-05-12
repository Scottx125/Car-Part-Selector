using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ComponentColourProperties", menuName = "ScriptableObjects/ComponentColourProperties", order = 2)]
public class ComponentColourProperties : ScriptableObject
{
    public Color colour;
    public float priceMod;
    public Image image;
}
