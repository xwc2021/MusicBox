using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBuilder : RecordDecorateBuilder
{
    [SerializeField] int recordCount;
    [SerializeField] OneMusic musicTemplate;
    [SerializeField] RectTransform musicContainer;
    [SerializeField] RectTransform music5Container;
    [SerializeField] RectTransform myListMusicContainer;
    [SerializeField] RectTransform refListMusicContainer;

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

    public void updateRefListMusic(JsonM<JRefListMusic> Obj)
    {
        batchAdd<JRefListMusic, OneMusic>(Obj.data, musicTemplate, refListMusicContainer);
    }

    
}
