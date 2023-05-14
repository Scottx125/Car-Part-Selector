using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "VehicleProperty", menuName = "ScriptableObjects/VehicleProperty", order = 1)]
public class VehicleComponentProperties : ScriptableObject
{
    public GameObject worldGameObj;
    public VehicleComponent type;
    public Sprite image;
    public string itemName;
    public float componentPrice;
    public Color defaultColour;
    public float colourPrice;
}
