using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OneList : MonoBehaviour {

    
    [SerializeField] RectTransform rect;
    [SerializeField] Text ListNameText;
    [SerializeField] Text AuthorText;
    [SerializeField] Text TotalPeopleText;

    public void refresh(JList record) {
        ListNameText.text = record.listname;
        AuthorText.text = record.authors;
        TotalPeopleText.text = $"{record.refcount}人已加入";
    }

    //發現Instantiate出來的UI會比較大
    //所以設定parent後，scale會跑掉，這裡主動重設scale
    public void setContainer(RectTransform container) {
        this.rect.SetParent(container);
        this.rect.localScale = Vector3.one;
    }
}
