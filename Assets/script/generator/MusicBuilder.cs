using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBuilder : RecordDecorateBuilder
{
    [SerializeField] OneMusic musicTemplate;
    [SerializeField] RectTransform musicContainer;
    [SerializeField] RectTransform music5Container;
    [SerializeField] RectTransform myListMusicContainer;
    [SerializeField] RectTransform MusicRepolistMusicContainer;

    public void updateMusic(JsonM<JMusic> Obj)
    {
        batchAdd<JMusic, OneMusic>(Obj.data, musicTemplate, musicContainer);
    }

    public void updateMusic5(JsonM<JMusic> Obj)
    {
        batchAdd<JMusic, OneMusic>(Obj.data, musicTemplate, music5Container);
    }

    public void updateListMusic(JsonM<JListMusic> Obj, bool tabMusicRepo)
    {
        RectTransform target = tabMusicRepo ? MusicRepolistMusicContainer : myListMusicContainer;
        batchAdd<JListMusic, OneMusic>(Obj.data, musicTemplate, target);
    }

    
}
