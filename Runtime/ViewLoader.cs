using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewLoader : MonoBehaviour
{
    public static IView Load(Transform tran,ViewScheme scheme,string path)
    {
        IView v = Load(tran, scheme);
        Debug.Log(scheme + path);
        v.Setup(path);
        return v;
    }
    //public static void Load(Transform tran,ViewData viewData)
    //{
    //    viewData.View = Load(tran, viewData.Scheme);
    //    viewData.View.Setup(viewData.Path);
    //}

    public static IView Load(Transform tran,ViewScheme scheme)
    {
        GameObject go = Instantiate(Resources.Load<GameObject>(scheme.ToString()), tran);
        return go.GetComponent<IView>();
    }
}
