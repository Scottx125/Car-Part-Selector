using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryGameObj;
    [SerializeField]
    VehicleComponent type; 
    
    VehicleComponentProperties[] vehiclePropertyArray;
    List<GameObject> inventoryGameObjList = new List<GameObject>();

    void Awake()
    {
        vehiclePropertyArray = Resources.LoadAll<VehicleComponentProperties>("ScriptableObjects/" + type.ToString());
        foreach (VehicleComponentProperties item in vehiclePropertyArray){
                GameObject instance = Instantiate(inventoryGameObj, transform);
                instance.GetComponent<InventoryAsset>().data = item;
                inventoryGameObjList.Add(instance);
        }
    }
}
