using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBuilder : MonoBehaviour {
    [SerializeField] OneMusic musicTemplate;
    [SerializeField] RectTransform musicContainer;
    [SerializeField] RectTransform music5Container;
    [SerializeField] RectTransform listMusicContainer;
    [SerializeField] RectTransform refListMusicContainer;

    public void updateMusic(JsonM<JMusic> Obj)
    {
        updateMusic(Obj, musicContainer);
    }

    public void updateMusic5(JsonM<JMusic> Obj)
    {
        updateMusic(Obj, music5Container);
    }

    //這裡有優化的空間
    void updateMusic(JsonM<JMusic> Obj, RectTransform container)
    {
        container.DetachChildren();//清空

        var length = Obj.data.Count;
        for (int i = 0; i < length; i++)
            add(Obj.data[i], container);
    }

    void add(JMusic record, RectTransform container)
    {
        OneMusic newList = Instantiate<OneMusic>(musicTemplate, container);
        newList.refreshMusic(record);
    }

    public void updateMyListMusic(JsonM<JMyListMusic> Obj)
    {
        listMusicContainer.DetachChildren();//清空

        var length = Obj.data.Count;
        for (int i = 0; i < length; i++)
            add(Obj.data[i], listMusicContainer);
    }

    void add(JMyListMusic record, RectTransform container)
    {
        OneMusic newList = Instantiate<OneMusic>(musicTemplate, container);
        newList.refreshMusic(record);
    }


    
    public void updateRefListMusic(JsonM<JRefListMusic> Obj)
    {
        refListMusicContainer.DetachChildren();//清空

        var length = Obj.data.Count;
        for (int i = 0; i < length; i++)
            add(Obj.data[i], refListMusicContainer);
    }

    void add(JRefListMusic record, RectTransform container)
    {
        OneMusic newList = Instantiate<OneMusic>(musicTemplate, container);
        newList.refreshMusic(record);
    }
}
