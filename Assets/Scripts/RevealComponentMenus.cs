using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealComponentMenus : MonoBehaviour
{
    [SerializeField]
    private bool isCarMenu;
    
    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        if (isCarMenu == false)
        {
            this.gameObject.SetActive(false);
            MenuSelection.RevealAdditionalComponenets += RevealMenu;
        }
        else { this.gameObject.SetActive(true); }
    }

    private void RevealMenu(){
        this.gameObject.SetActive(true);
        MenuSelection.RevealAdditionalComponenets -= RevealMenu;
    }
}
