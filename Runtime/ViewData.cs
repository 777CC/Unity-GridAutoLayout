using UnityEngine;
[System.Serializable]
public enum ViewScheme
{
    RTSP,
    Map
}
[System.Serializable]
public struct ViewData
{
    public IView View;
    public ViewScheme Scheme;
    public string Path;
    public int Column;
    public int Row;
    public int Width;
    public int Height;
}