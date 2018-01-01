using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBuilder : RecordDecorateBuilder
{
    [SerializeField] OneMusic musicTemplate;
    [SerializeField] RectTransform musicContainer;
    [SerializeField] RectTransform music5Container;
    [SerializeField] RectTransform myListMusicContainer;
    [SerializeField] RectTransform listMusicContainer;

    public void updateMusic(JsonM<JMusic> Obj)
    {
        batchAdd<JMusic, OneMusic>(Obj.data, musicTemplate, musicContainer);
    }

    public void updateMusic5(JsonM<JMusic> Obj)
    {
        batchAdd<JMusic, OneMusic>(Obj.data, musicTemplate, music5Container);
    }

    public void updateMyListMusic(JsonM<JMyListMusic> Obj)
    {
        batchAdd<JMyListMusic, OneMusic>(Obj.data, musicTemplate, myListMusicContainer);
    }

    public void updateRefListMusic(JsonM<JListMusic> Obj)
    {
        batchAdd<JListMusic, OneMusic>(Obj.data, musicTemplate, listMusicContainer);
    }

    
}
