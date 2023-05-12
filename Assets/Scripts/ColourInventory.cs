using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourInventory : MonoBehaviour
{
    [SerializeField]
    GameObject colourInventoryGameObj;
    
    ComponentColourProperties[] componentColour;

    void Awake()
    {
       componentColour = Resources.LoadAll<ComponentColourProperties>("ScriptableObjects/Colour");
        foreach (ComponentColourProperties item in componentColour){
                GameObject instance = Instantiate(colourInventoryGameObj, transform);
                instance.GetComponent<ColourAsset>().data = item;
        }
    }
}
