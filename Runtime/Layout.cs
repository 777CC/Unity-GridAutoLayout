using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout : MonoBehaviour
{
    public View[] views;
    Vector2 anchorMin = Vector2.zero;
    Vector2 anchorMax = Vector2.one;
    Vector2 offsetMin = Vector2.zero;
    Vector2 offsetMax = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var v in views)
        {
            v.HideOtherViewButton = FocusOnView;
            Debug.Log(v.recttest.x);

        }
    }

    void FocusOnView(View view)
    {
        foreach (var v in views)
        {
            if (v != view) v.Unfocus();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
