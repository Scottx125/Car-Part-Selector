using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "VehicleProperty", menuName = "ScriptableObjects/VehicleProperty", order = 1)]
public class VehicleComponentProperties : ScriptableObject
{
    public GameObject getWorldGameObj => worldGameObj;
    public VehicleComponent getVehicleCompType => vehicleCompType;
    public Sprite getImage => image;
    public string getItemName => itemName;
    public float getComponentPrice => componentPrice;
    public Color getDefaultColour => defaultColour;
    public float getColourPrice => colourPrice;
    public float getSpeed => speed;

    [SerializeField]
    private GameObject worldGameObj;
    [SerializeField]
    private VehicleComponent vehicleCompType;
    [SerializeField]
    private Sprite image;
    [SerializeField]
    private string itemName;
    [SerializeField]
    private Color defaultColour;
    [SerializeField]
    private float colourPrice, speed, componentPrice;
}
