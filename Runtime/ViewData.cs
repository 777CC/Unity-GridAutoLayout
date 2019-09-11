using UnityEngine;
[System.Serializable]
public enum ViewScheme
{
    RTSP,
    Map,
    Grid,
}
[System.Serializable]
public class GridContentData
{
    public GridContentData(ViewScheme vs,string path,int col,int row,int w,int h)
    {
        Scheme = vs;
        View = null;
        Path = path;
        Column = col;
        Row = row;
        Width = w;
        Height = h;
    }
    public IView View;
    public ViewScheme Scheme;
    public string Path;
    public int Column;
    public int Row;
    public int Width;
    public int Height;
}