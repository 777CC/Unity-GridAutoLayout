using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout : MonoBehaviour
{
    [SerializeField]
    int Column = 1;
    [SerializeField]
    int Row = 1;
    public ViewData[] viewList;
    //public View[] views;
    Vector2 anchorMin = Vector2.zero;
    Vector2 anchorMax = Vector2.one;
    Vector2 offsetMin = Vector2.zero;
    Vector2 offsetMax = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        //foreach(var v in views)
        //{
        //    v.HideOtherViewButton = FocusOnView;
        //    Debug.Log(v.recttest.x);
        //}
        RectTransform layoutRect = GetComponent<RectTransform>();
        float sizeX = layoutRect.rect.size.x / Column;
        float sizeY = layoutRect.rect.size.y / Row;
        Debug.Log(layoutRect.sizeDelta.x + " : " + Column + " : " + sizeX + " : " + sizeY);
        foreach (var v in viewList)
        {
            v.View.HideOtherViewButton = FocusOnView;
            GameObject go = v.View.gameObject;
            RectTransform rect = go.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0, 0.5f);
            rect.anchorMax = new Vector2(0, 0.5f);
            rect.pivot = Vector2.zero;
            //rect.anchoredPosition3D = new Vector3(v.Column, v.Row,0);
            //rect.sizeDelta = new Vector2(100, 100);

            rect.anchoredPosition3D = new Vector3((v.Column - 1) * sizeX,(v.Row - 1) * -sizeY, 0);
            rect.sizeDelta = new Vector2(sizeX, sizeY);

        }
    }

    void FocusOnView(View view)
    {
        foreach (var vData in viewList)
        {
            if (vData.View != view) vData.View.Unfocus();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
