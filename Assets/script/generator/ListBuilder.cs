using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListBuilder : MonoBehaviour {
    [SerializeField] OneList listTemplate;
    [SerializeField] RectTransform container;

    //這裡有優化的空間
    public void updateContainer(JsonM<JList> Obj)
    {
        container.DetachChildren();//清空

        var length = Obj.data.Count;
        for (int i = 0; i < length; i++)
            add(Obj.data[i], container);
    }

    void add(JList record, RectTransform container)
    {
        OneList newList = Instantiate<OneList>(listTemplate);
        newList.refresh(record);
        newList.setContainer(container);
    }
}
