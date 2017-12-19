using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(GridLayoutGroup))]
public class AutoResizeGridLayout : MonoBehaviour {

    enum AutoResizeDirection {x,y };

    [SerializeField]
    private int itemCount=2;

    [SerializeField]
    private AutoResizeDirection direction = AutoResizeDirection.y;

    [SerializeField]
    private int constraintCount=2;
    private RectTransform targetRect;
    private GridLayoutGroup gridLayoutGroup;

    // Use this for initialization
    void Awake () {
        targetRect=this.GetComponent<RectTransform>();
        gridLayoutGroup = this.GetComponent<GridLayoutGroup>();
        setItemCount(itemCount);
    }
	
	// Update is called once per frame
	void Update () {
        setItemCount(itemCount);
    }

    //根據count更新RectTransform的height
    public void setItemCount(int count) {
        int groupCount = (int)Mathf.Ceil((float)count / constraintCount);

        //sizeDelta
        //有Stretch時 正值代表加長，負值代表減短，0代表不變
        //沒有Stretch時，則是設定width或height的值
        if (direction == AutoResizeDirection.y)//垂直方向
        {
            float newValue = getTotalValue(groupCount, gridLayoutGroup.cellSize.y, gridLayoutGroup.spacing.y);
            //有Stretch
            targetRect.sizeDelta = new Vector2(0, newValue);
        }
        else
        {
            float newValue = getTotalValue(groupCount, gridLayoutGroup.cellSize.x, gridLayoutGroup.spacing.x);
            //有Stretch
            targetRect.sizeDelta = new Vector2(newValue, 0);
        }
    }

    private float getTotalValue(int count,float cellSize,float space){
        return count * cellSize
            + (count + 1) * space;
    }
}
