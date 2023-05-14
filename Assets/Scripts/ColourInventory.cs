using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColourInventory : MonoBehaviour
{
    [SerializeField]
    GameObject colourInventoryGameObj;
    
    ComponentColourProperties[] componentColourArray;
    List<GameObject> colourInventoryGameObjList = new List<GameObject>();

    void OnEnable(){
        MenuSelection.OnNewSelection += UpdateColourAssets;
    }
    void OnDisable(){
        MenuSelection.OnNewSelection += UpdateColourAssets;
    }

    void Awake()
    { 
        // Might need to either force an update OR apply data to object before it's instantiated.
        componentColourArray = Resources.LoadAll<ComponentColourProperties>("ScriptableObjects/Colour");

        SortArrayDefaultFirst();
        foreach (ComponentColourProperties item in componentColourArray){
                GameObject instance = Instantiate(colourInventoryGameObj, transform);
                instance.GetComponent<ColourAsset>().data = item;
                colourInventoryGameObjList.Add(instance);
        }
    }

    void SortArrayDefaultFirst()
    {
        if (!Array.Find(componentColourArray, x => x.isDefaultColour == true)){return;}
        
        int index = Array.FindIndex(componentColourArray, x => x.isDefaultColour == true);
        // Switcharoo to put the default at the start.
        ComponentColourProperties temp = componentColourArray[0];
        componentColourArray[0] = componentColourArray[index];
        componentColourArray[index] = temp;
    }

    void UpdateColourAssets(float colourPrice, Color baseColour, VehicleComponent type){
        // Update the first default colour here.
        colourInventoryGameObjList[0].GetComponent<ColourAsset>().DefaultColourUpdate(baseColour);
        foreach (GameObject item in colourInventoryGameObjList){
            item.GetComponent<ColourAsset>().UpdateStats(colourPrice, type);
        }
    }
}
