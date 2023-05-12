using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryGameObj;
    [SerializeField]
    VehicleComponent type; 
    VehiclePropertyScriptableObject[] vehicleProperty;
    GameObject[] inventoryGameObjArray;

    void Awake()
    {
        vehicleProperty = Resources.LoadAll<VehiclePropertyScriptableObject>("ScriptableObjects/" + type.ToString());
        inventoryGameObjArray = new GameObject[vehicleProperty.Length];
        foreach (VehiclePropertyScriptableObject item in vehicleProperty){
            for (int i = 0; i < inventoryGameObjArray.Length; i++){
                inventoryGameObjArray[i] = Instantiate(inventoryGameObj, transform);
                inventoryGameObjArray[i].GetComponent<InventoryAsset>().data = item;
            }
        }
    }
}
