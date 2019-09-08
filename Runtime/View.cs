using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class View : MonoBehaviour, IView, IPointerEnterHandler, IPointerExitHandler
{
    public string Path;
    public Button Fullscreen;
    public LayoutCall HideOtherViewButton;
    //public LayoutCall ToFullScreen;
    private int OldIndex;
    private RectTransform rect;
    private Vector2 oldAnchorMin, oldAnchorMax, oldOffsetMin, oldOffsetMax,oldSize;
    private Vector3 oldPos;
    private Transform oldParent;
    public bool isFullScreen = false;
    public void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    public virtual void Play(string path)
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HideOtherViewButton?.Invoke(this);
        if (Fullscreen != null)
        {
            Fullscreen.gameObject.SetActive(true);
        }
    }

    public void Unfocus()
    {
        if (Fullscreen != null)
        {
            Fullscreen.gameObject.SetActive(false);
        }
    }

    public void ShowFullScreen()
    {
        Debug.Log("pos : " + rect.anchoredPosition3D + " old: " + oldPos);
        //Debug.Log("pos : " + rect.anchoredPosition3D + "amin : " + rect.anchorMin + " amax : " + rect.anchorMax + " omin : " + rect.offsetMin + " omax : " + rect.offsetMax);
        if (!isFullScreen)
        {
            Canvas cv = GetComponentInParent<Canvas>();
            
            //Save old rect.
            oldParent = transform.parent;
            OldIndex = transform.GetSiblingIndex();
            oldPos = rect.anchoredPosition3D;
            oldAnchorMin = rect.anchorMin;
            oldAnchorMax = rect.anchorMax;
            oldOffsetMin = rect.offsetMin;
            oldOffsetMax = rect.offsetMax;
            oldSize = rect.sizeDelta;
            //Move to top.
            transform.SetParent(cv.transform);
            transform.SetSiblingIndex(transform.parent.childCount - 1);
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            isFullScreen = true;
        }
        else
        {
            transform.SetParent(oldParent);
            
            transform.SetSiblingIndex(OldIndex);
            

            
            rect.anchorMin = oldAnchorMin;
            rect.anchorMax = oldAnchorMax;
            rect.offsetMin = oldOffsetMin;
            rect.offsetMax = oldOffsetMax;  
            rect.anchoredPosition = oldPos;


            isFullScreen = false;

            
        }
        Debug.Log("pos : " + rect.anchoredPosition3D + " old: " + oldPos);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (Fullscreen != null)
        {
            Fullscreen.gameObject.SetActive(false);
        }
    }

    public void SetOnLayoutCall(LayoutCall layoutCall)
    {
        HideOtherViewButton = layoutCall;
    }
    public RectTransform GetRectTranform()
    {
        return GetComponent<RectTransform>();
    }
}
