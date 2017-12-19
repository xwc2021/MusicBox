using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(GridLayoutGroup))]
public class AutoResizeGridLayout : MonoBehaviour {


    [SerializeField]
    private int itemCount=2;

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
		
	}

    //根據count更新RectTransform的height
    public void setItemCount(int count) {
        this.itemCount = count;

        float rowCount = (count + 1) / 2;
        float newHeight = rowCount * gridLayoutGroup.cellSize.y
            + (rowCount + 1) * gridLayoutGroup.spacing.y;

        //sizeDelta
        //有Stretch時 正值代表加長，負值代表減短，0代表不變
        //沒有Stretch時，則是設定width或height的值
        
        //下面有Stretch
        targetRect.sizeDelta = new Vector2(0, newHeight);
    }
}
