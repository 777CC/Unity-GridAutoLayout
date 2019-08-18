using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class View : MonoBehaviour, IPointerEnterHandler
{
    public Button Fullscreen;
    public delegate void LayoutCall(View view);
    public LayoutCall HideOtherViewButton;
    //public LayoutCall ToFullScreen;
    private int OldIndex;
    private RectTransform rect;
    private Vector2 oldAnchorMin, oldAnchorMax, oldOffsetMin, oldOffsetMax;
    public bool isFullScreen = false;
    public Rect recttest;
    public void Start()
    {
        OldIndex = transform.GetSiblingIndex();
        rect = GetComponent<RectTransform>();
        oldAnchorMin = rect.anchorMin;
        oldAnchorMax = rect.anchorMax;
        oldOffsetMin = rect.offsetMin;
        oldOffsetMax = rect.offsetMax;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HideOtherViewButton?.Invoke(this);
        Fullscreen.gameObject.SetActive(true);
    }

    public void Unfocus()
    {
        Fullscreen.gameObject.SetActive(false);
    }

    public void ShowFullScreen()
    {
        Debug.Log("amin : " + rect.anchorMin + " amax : " + rect.anchorMax + " omin : " + rect.offsetMin + " omax : " + rect.offsetMax);
        if (!isFullScreen)
        {
            transform.SetSiblingIndex(transform.parent.childCount - 1);
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            isFullScreen = true;
        }
        else
        {
            rect.anchorMin = oldAnchorMin;
            rect.anchorMax = oldAnchorMax;
            rect.offsetMin = oldOffsetMin;
            rect.offsetMax = oldOffsetMax;
            transform.SetSiblingIndex(OldIndex);
            isFullScreen = false;
        }
    }
    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    Fullscreen.gameObject.SetActive(false);
    //}
}
