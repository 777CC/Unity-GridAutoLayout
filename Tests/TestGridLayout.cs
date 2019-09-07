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
        GameObject go = Instantiate(Resources.Load<GameObject>("rtsp"), layout.transform);
        View v = go.GetComponent<View>();
        layout.viewList = new ViewData[1];
        ViewData vData = new ViewData();
        vData.View = v;
        vData.Column = 2;
        vData.Row = 1;
        vData.Width = 1;
        vData.Height = 1;
        vData.Scheme = ViewScheme.RTSP;
        vData.Path = "wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov";
        IView iv = go.GetComponent<IView>();
        iv.Play(vData.Path);
        //v.Play(vData.Path);
        layout.viewList[0] = vData;
        layout.UpdateLayout();
    }
}
