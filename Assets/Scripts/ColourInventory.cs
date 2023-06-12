using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColourInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject colourInventoryGameObj;
    
    private ComponentColourProperties[] componentColourArray;
    private List<ColourAsset> colourAssetInventory = new List<ColourAsset>();

    private void OnEnable(){
        MenuSelection.OnNewSelection += UpdateColourAssets;
    }
    private void OnDisable(){
        MenuSelection.OnNewSelection += UpdateColourAssets;
    }

    private void Awake()
    {
        SetupAssets();
    }

    private void SetupAssets()
    {
        // Might need to either force an update OR apply data to object before it's instantiated.
        componentColourArray = Resources.LoadAll<ComponentColourProperties>("ScriptableObjects/Colour");

        SortArrayDefaultFirst();
        foreach (ComponentColourProperties item in componentColourArray)
        {
            GameObject instance = Instantiate(colourInventoryGameObj, transform);
            ColourAsset asset = instance.GetComponent<ColourAsset>();
            if (asset == null)
            {
                return;
            }
            asset.data = item;
            asset.Setup();
            colourAssetInventory.Add(asset);
        }
    }

    private void SortArrayDefaultFirst()
    {
        if (!Array.Find(componentColourArray, x => x.getIsDefaultColour == true)){return;}
        
        int index = Array.FindIndex(componentColourArray, x => x.getIsDefaultColour == true);
        // Switcharoo to put the default at the start.
        ComponentColourProperties temp = componentColourArray[0];
        componentColourArray[0] = componentColourArray[index];
        componentColourArray[index] = temp;
    }

    private void UpdateColourAssets(float colourPrice, Color baseColour, VehicleComponent type){
        // Update the first default colour here.
        colourAssetInventory[0].DefaultColourUpdate(baseColour);
        foreach (ColourAsset item in colourAssetInventory){
            item.UpdateStats(colourPrice, type);
        }
    }
}
