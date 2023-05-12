using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevealPanel : MonoBehaviour
{
    [SerializeField]
    GameObject parent;
    [SerializeField]
    GameObject hiddenPanel;

    RectTransform parentRect;
    RectTransform hiddenPanelRect;
    float hiddenPanelHeight;
    float parentHeight;
    float parentHeightOffset;

    void Awake(){
        parentRect = parent.GetComponent<RectTransform>();
        hiddenPanelRect = gameObject.GetComponent<RectTransform>();
        parentHeight = parentRect.rect.height;
        parentHeightOffset = parent.GetComponent<VerticalLayoutGroup>().spacing;
        hiddenPanelHeight = hiddenPanelRect.rect.height;
    }

    public void OnButtonClick(){
        if (gameObject.activeSelf == false){
            SetActive();
        } else {SetInactive();}
    }

    void SetActive(){
        hiddenPanel.SetActive(true);
        float combinedHeight = parentHeight + hiddenPanelHeight;
        parentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, combinedHeight + parentHeightOffset);
    }
    void SetInactive(){
        hiddenPanel.SetActive(false);
        parentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, parentHeight);
    }
}
