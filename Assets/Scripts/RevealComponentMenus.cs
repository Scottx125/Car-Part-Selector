using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealComponentMenus : MonoBehaviour
{
    [SerializeField]
    private bool isCarMenu;
    
    private void Awake(){
        if (isCarMenu == false){
            this.gameObject.SetActive(false);
            MenuSelection.FirstSelection += RevealMenu;
        } else {this.gameObject.SetActive(true);}
    }

    private void RevealMenu(){
        this.gameObject.SetActive(true);
        MenuSelection.FirstSelection -= RevealMenu;
    }
}
