using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyListBuilder : MonoBehaviour {
    [SerializeField] OneList listTemplate;
    [SerializeField] RectTransform myListContainer;
    [SerializeField] RectTransform listContainer;

    //這裡有優化的空間
    public void updateMyList(JsonM<JMyList> Obj)
    {
        myListContainer.DetachChildren();//清空

        var length = Obj.data.Count;
        for (int i = 0; i < length; i++)
            add(Obj.data[i], myListContainer);
    }

    void add(JMyList record, RectTransform container)
    {
        OneList newList = Instantiate<OneList>(listTemplate,container);
        newList.refreshMyList(record);
    }

    public void updateList(JsonM<JRealList> Obj)
    {
        listContainer.DetachChildren();//清空

        var length = Obj.data.Count;
        for (int i = 0; i < length; i++)
            add(Obj.data[i], listContainer);
    }

    void add(JRealList record, RectTransform container)
    {
        OneList newList = Instantiate<OneList>(listTemplate, container);
        newList.refreshList(record);
    }
}
