using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourInventory : MonoBehaviour
{
    [SerializeField]
    GameObject colourInventoryGameObj;
    
    ComponentColourProperties[] componentColourArray;
    List<GameObject> colourInventoryGameObjList = new List<GameObject>();

    void OnEnabled(){
        MenuSelection.OnNewSelection += UpdateColourAssets;
    }
    void OnDisabled(){
        MenuSelection.OnNewSelection += UpdateColourAssets;
    }

    void Awake()
    { 
       componentColourArray = Resources.LoadAll<ComponentColourProperties>("ScriptableObjects/Colour");
        foreach (ComponentColourProperties item in componentColourArray){
                GameObject instance = Instantiate(colourInventoryGameObj, transform);
                instance.GetComponent<ColourAsset>().data = item;
                colourInventoryGameObjList.Add(instance);
        }
        // Insert default at start.
    }

    void SetupDefault(){
        
    }

    void UpdateColourAssets(float colourPrice, Color baseColour, VehicleComponent type){
        // Update the first default colour here.
        foreach (GameObject item in colourInventoryGameObjList){
            item.GetComponent<ColourAsset>().UpdateStats(colourPrice, type);
        }
    }
}
