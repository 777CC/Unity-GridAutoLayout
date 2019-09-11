using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGridLayout : MonoBehaviour
{
    public Transform panelTran;
    public TextAsset text;
    public AutoSizingGridLayout layout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Test()
    {
        //LayoutData l = new LayoutData();
        //l.Column = 2;
        //l.Row = 2;
        //l.views = new GridContentData[2];
        //l.views[0] = new GridContentData(ViewScheme.RTSP, "wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov",1,1,1,1);
        //l.views[1] = new GridContentData(ViewScheme.RTSP, "wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov", 2, 2, 1, 1);
        //l.Name = "test";
        //Debug.Log(JsonUtility.ToJson(l));

        //layout.Setup(text.text);


        //View v = go.GetComponent<View>();
        //IView v = Instantiate(Resources.Load<GameObject>("rtsp"));
        //layout.viewList = new ViewData[1];
        //ViewData vData = new ViewData();
        //vData.View = go.GetComponent<IView>();
        //vData.Column = 2;
        //vData.Row = 1;
        //vData.Width = 1;
        //vData.Height = 1;
        //vData.Scheme = ViewScheme.RTSP;
        //vData.Path = "wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov";
        //vData.View.Play(vData.Path);
        //v.Play(vData.Path);
        //layout.viewList[0] = vData;
        //layout.UpdateLayout();
    }

    public void TestGrid()
    {
        //ViewLoader.Load(panelTran, ViewScheme.Grid, text.text);
        //LayoutData layout2 = new LayoutData();
        //layout2.Name = "Child";
        //layout2.Column = 2;
        //layout2.Row = 2;
        //layout2.views = new GridContentData[1];
        //layout2.views[0] = new GridContentData(ViewScheme.RTSP, "wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov",1,1,1,1);
        //LayoutData layout = new LayoutData();
        //layout.Name = "Main";
        //layout.Column = 2;
        //layout.Row = 2;
        //layout.views = new GridContentData[1];
        //layout.views[0] = new GridContentData(ViewScheme.Grid, JsonUtility.ToJson(layout2,true), 2, 1, 1, 1);

        //ViewLoader.Load(panelTran, ViewScheme.Grid,JsonUtility.ToJson(layout,true));
        string uri = @"http://2:2@test/?tag=2:2@test/?tag=&order=newest&order=newest";
        Uri test = new Uri(uri);
        Debug.Log("Name : " + test.UserInfo + " col : " + test.Host + " row : " + test.Port + " query : " + test.Query);
    }
}
