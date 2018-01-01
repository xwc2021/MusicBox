using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneMusic : MonoBehaviour, RecordDecorate<JMusic>, RecordDecorate<JMyListMusic>,RecordDecorate<JRefListMusic>
{
    [SerializeField] Text musicName;
    [SerializeField] Text author;
    void RecordDecorate<JMusic>.refreshUI(JMusic record)
    {
        musicName.text = record.musicname;
        author.text = record.authors;
    }

    void RecordDecorate<JMyListMusic>.refreshUI(JMyListMusic record)
    {
        musicName.text = record.musicname;
        //author.text = record.authors;
    }

    void RecordDecorate<JRefListMusic>.refreshUI(JRefListMusic record)
    {
        musicName.text = record.musicname;
        //author.text = record.authors;
    }
}
