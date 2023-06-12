using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryGameObj;
    [SerializeField]
    private VehicleComponent type; 
    
    private VehicleComponentProperties[] vehiclePropertyArray;
    private List<InventoryAsset> inventoryGameObjList = new List<InventoryAsset>();

    private void Awake()
    {
        SetupAssets();
    }

    private void SetupAssets()
    {
        vehiclePropertyArray = Resources.LoadAll<VehicleComponentProperties>("ScriptableObjects/" + type.ToString());

        foreach (VehicleComponentProperties item in vehiclePropertyArray)
        {
            GameObject instance = Instantiate(inventoryGameObj, transform);
            InventoryAsset asset = instance.GetComponent<InventoryAsset>();
            if (asset == null)
            {
                return;
            }
            asset.data = item;
            asset.Setup();
            inventoryGameObjList.Add(asset);
        }
    }
}
