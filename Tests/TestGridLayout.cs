using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGridLayout : MonoBehaviour
{
    public AutoSizingGridLayout layout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Test()
    {
        ViewData[] views = new ViewData[2];
        views[0] = new ViewData(ViewScheme.RTSP, "wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov",1,1,1,1);
        views[1] = new ViewData(ViewScheme.RTSP, "wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov", 2, 2, 1, 1);

        layout.SetContent(views);
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
}
