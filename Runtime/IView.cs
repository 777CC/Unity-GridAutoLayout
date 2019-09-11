using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void LayoutCall(View view);
public interface IView
{
    void SetOnLayoutCall(LayoutCall layoutCall);
    RectTransform GetRectTranform();
    void Setup(string path);
    void Unfocus();
}
