using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListBuilder : RecordDecorateBuilder
{
    [SerializeField] OneList listTemplate;
    [SerializeField] RectTransform myListContainer;
    [SerializeField] RectTransform listContainer;
    [SerializeField] RectTransform list5Container;

    //這裡有優化的空間
    public void updateMyList(JsonM<JMyList> Obj)
    {
        batchAdd<JMyList, OneList>(Obj.data, listTemplate, myListContainer);
    }

    public void updateList(JsonM<JRealList> Obj)
    {
        batchAdd<JRealList, OneList>(Obj.data, listTemplate, listContainer);
    }

    public void updateList5(JsonM<JRealList> Obj)
    {
        batchAdd<JRealList, OneList>(Obj.data, listTemplate, list5Container);
    }

}
