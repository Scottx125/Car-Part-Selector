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
    List<GameObject> inventoryGameObjArray = new List<GameObject>();

    void Awake()
    {
        vehicleProperty = Resources.LoadAll<VehiclePropertyScriptableObject>("ScriptableObjects/" + type.ToString());
        foreach (VehiclePropertyScriptableObject item in vehicleProperty){
                GameObject instance = Instantiate(inventoryGameObj, transform);
                instance.GetComponent<InventoryAsset>().data = item;
                inventoryGameObjArray.Add(instance);
        }
    }
}
