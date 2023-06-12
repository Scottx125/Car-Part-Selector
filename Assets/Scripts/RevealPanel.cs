using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevealPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject parent, hiddenPanel;

    private RectTransform parentRect, hiddenPanelRect;
    private float hiddenPanelHeight, parentHeight, parentHeightOffset;

    private void Awake()
    {
        Setup();
    }

    public void OnButtonClick(){
        if (gameObject.activeSelf == false){
            SetActive();
        } else {SetInactive();}
    }

    private void Setup()
    {
        parentRect = parent.GetComponent<RectTransform>();
        hiddenPanelRect = gameObject.GetComponent<RectTransform>();
        parentHeight = parentRect.rect.height;
        parentHeightOffset = parent.GetComponent<VerticalLayoutGroup>().spacing;
        hiddenPanelHeight = hiddenPanelRect.rect.height;
    }

    private void SetActive(){
        hiddenPanel.SetActive(true);
        float combinedHeight = parentHeight + hiddenPanelHeight;
        parentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, combinedHeight + parentHeightOffset);
    }
    private void SetInactive(){
        hiddenPanel.SetActive(false);
        parentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, parentHeight);
    }
}
