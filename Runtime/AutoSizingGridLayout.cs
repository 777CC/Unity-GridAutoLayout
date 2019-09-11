using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LayoutData
{
    public string Name;
    public GridContentData[] views;
    public int Column;
    public int Row;
}


public class AutoSizingGridLayout : View
{
    [SerializeField]
    int Column = 1;
    [SerializeField]
    int Row = 1;
    [SerializeField]
    private GridContentData[] viewList;
    //public View[] views;
    Vector2 anchorMin = Vector2.zero;
    Vector2 anchorMax = Vector2.one;
    Vector2 offsetMin = Vector2.zero;
    Vector2 offsetMax = Vector2.zero;
    string httpScheme = "http://";
    // Start is called before the first frame update
    void Start()
    {
        UpdateLayout();
    }

    //Path Format must be "RTSP,test001,1,1,1,1|RTSP,test002,2,1,1,1"
    //Use '|' to split content.
    //Use ',' to split content value.
    //Content value index is
    //scheme,path,column,row,width,height
    public override void Setup(string path)
    {
        //string[] data = path.Split('/');
        //Name = data[0];
        //Debug.Log(data[1]);
        //string prepared = path.Replace('"'.ToString(), "\\\"");
        Debug.Log(path);
        
        LayoutData l = JsonUtility.FromJson<LayoutData>(path);
        Name = l.Name;
        Column = l.Column;
        Row = l.Row;
        SetContent(l.views);



        //Uri grid = new Uri(httpScheme + path);

        ////Define grid column and row.
        //string[] size = grid.UserInfo.Split(':');
        //if (size.Length != 2) return;
        //Column = int.Parse(size[0]);
        //Row = int.Parse(size[1]);

        ////Define grid name.
        //Name = grid.Host;

        ////Define grid content.
        //string contentValue = grid.Query.Substring(1);
        //string[] contentData = contentValue.Split('&');
        //GridContentData[] contents = new GridContentData[contentData.Length];
        //for(int i = 0; i < contentData.Length; i++)
        //{
        //    string[] nameandvalue = contentData[i].Split('=');
        //    string name = nameandvalue[0];
        //    string[] values = nameandvalue[1].Split(',');
        //    if(values.Length == 6)
        //    {
        //        Debug.Log(values[0] + values[1]);
        //        ViewScheme scheme = (ViewScheme)Enum.Parse(typeof(ViewScheme), values[0]);
        //        string contentPath = values[1];
        //        int col = int.Parse(values[2]);
        //        int row = int.Parse(values[3]);
        //        int w = int.Parse(values[4]);
        //        int h = int.Parse(values[5]);
        //        contents[i] = new GridContentData(scheme, contentPath, col, row, w, h);
        //    }
        //}

        //SetContent(contents);
    }

    private void SetContent(GridContentData[] dataList)
    {
        viewList = dataList;
        for (int i = 0;i < viewList.Length;i++)
        {
            if (!string.IsNullOrEmpty(viewList[i].Path) && viewList[i].Path != "Null")
            {
                Debug.Log(viewList[i].Path);
                viewList[i].View = ViewLoader.Load(transform, viewList[i].Scheme, viewList[i].Path);
            }
            else
            {
                string data = JsonUtility.ToJson(viewList[i].Content);
                Debug.Log(data);
                viewList[i].View = ViewLoader.Load(transform, viewList[i].Scheme, data);
            }
            //ViewLoader.Load(transform,viewList[i]);
            //viewList[i].View = ViewLoader.Load(transform, viewList[i].Scheme);
            //viewList[i].View.Setup(viewList[i].Path);
            //Debug.Log(JsonUtility.ToJson(viewList[i]));
        }
        UpdateLayout();
    }

    public void UpdateLayout()
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
            //v.View.HideOtherViewButton = FocusOnView;
            //GameObject go = v.View.gameObject;
            //RectTransform r = go.GetComponent<RectTransform>();
            v.View.SetOnLayoutCall(FocusOnView);
            RectTransform r = v.View.GetRectTranform();
            r.anchorMin = new Vector2(0, 0.5f);
            r.anchorMax = new Vector2(0, 0.5f);
            r.pivot = Vector2.zero;
            //rect.anchoredPosition3D = new Vector3(v.Column, v.Row,0);
            //rect.sizeDelta = new Vector2(100, 100);

            r.anchoredPosition3D = new Vector3((v.Column - 1) * sizeX, (v.Row - 1) * -sizeY, 0);
            r.sizeDelta = new Vector2(sizeX, sizeY);
            
            Debug.Log(r.anchoredPosition3D + r.gameObject.name);
            //Canvas.ForceUpdateCanvases();
        }
    }

    void FocusOnView(IView v)
    {
        foreach (var vData in viewList)
        {
            if (vData.View != v) vData.View.Unfocus();
        }
    }
}
