using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneMusic : MonoBehaviour, RecordDecorate<JMusic>,RecordDecorate<JListMusic>
{
    [SerializeField] Text musicName;
    [SerializeField] Text author;
    [SerializeField] Image image;
    void RecordDecorate<JMusic>.refreshUI(JMusic record)
    {
        musicName.text = record.musicname;
        author.text = record.authors;

        image.color =record.ismysong?Style.myColor:Style.otherColor;
    }

    void RecordDecorate<JListMusic>.refreshUI(JListMusic record)
    {
        musicName.text = record.musicname;
        author.text = record.authors;

        if (record.ismymusic)
            image.color = Style.myColor;
        else if (record.ismyref)
            image.color = Style.myRefColor;
        else
            image.color = Style.otherColor;
    }
}
