using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordDecorateBuilder : MonoBehaviour
{
    //這裡有優化的空間
    protected void batchAdd<JsonType, UIType>(List<JsonType> records, UIType template, RectTransform container) where UIType : MonoBehaviour
    {
        UIType[] old =container.GetComponentsInChildren<UIType>();
        for (int i = 0; i < old.Length; i++)
            Destroy(old[i].gameObject);

        records.ForEach(record =>
        {
            add<JsonType, UIType>(record, template, container);
        });
    }

    protected void add<JsonType, UIType>(JsonType record, UIType template, RectTransform container) where UIType : MonoBehaviour
    {
        UIType oneMusic = Instantiate<UIType>(template, container);
        RecordDecorate<JsonType> decorate = oneMusic.GetComponent<RecordDecorate<JsonType>>();
        decorate.refreshUI(record);
    }
}
