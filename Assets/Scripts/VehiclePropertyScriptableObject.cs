using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "VehicleProperty", menuName = "ScriptableObjects/VehicleProperty", order = 1)]
public class VehiclePropertyScriptableObject : ScriptableObject
{
    public GameObject worldGameObj;
    public Image image;
    public string itemName;
    public float price;
    public Color defaultColour;
}
