using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(UnityEngine.UI.GridLayoutGroup))]
public class AdjustGridLayoutCellSize : MonoBehaviour
{
    public enum ExpandSetting { X, Y, };

    public ExpandSetting expandingSetting;
    GridLayoutGroup gridlayout;
    int maxConstraintCount = 0;
    RectTransform layoutRect;
    private void Awake()
    {
        gridlayout = GetComponent<GridLayoutGroup>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateCellSize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnValidate()
    {
        UpdateCellSize();
        View[] views = GetComponentsInChildren<View>();
        foreach(View v in views)
        {
            Debug.Log(v.isFullScreen);
        }
    }

    private void UpdateCellSize()
    {
        maxConstraintCount = gridlayout.constraintCount;
        layoutRect = gridlayout.gameObject.GetComponent<RectTransform>();

        if (expandingSetting == ExpandSetting.X)
        {
            float width = layoutRect.rect.width;
            float sizePerCell = width / maxConstraintCount;
            gridlayout.cellSize = new Vector2(sizePerCell, gridlayout.cellSize.y);
        }
        else if (expandingSetting == ExpandSetting.Y)
        {
            float height = layoutRect.rect.height;
            float sizePerCell = height / maxConstraintCount;
            gridlayout.cellSize = new Vector2(gridlayout.cellSize.x, sizePerCell);
        }
    }

    private void OnRectTransformDimensionsChange()
    {
        Debug.Log("Test");
    }
}