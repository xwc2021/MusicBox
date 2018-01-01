using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OneList : MonoBehaviour,RecordDecorate<JMyList>,RecordDecorate<JRealList>
{
    [SerializeField] RectTransform rect;
    [SerializeField] Text ListName;
    [SerializeField] Text Author;
    [SerializeField] Text TotalPeople;
    [SerializeField] Image image;

    static Color myListColor = new Color(221.0f / 255, 252.0f / 255, 255.0f / 255);//水藍
    static Color myRefListColor = new Color(212.0f / 255, 240.0f / 255, 194.0f / 255);//淡綠
    static Color listColor = new Color(255.0f / 255, 201.0f / 255, 201.0f / 255);//粉紅

    void RecordDecorate<JMyList>.refreshUI(JMyList record)
    {
        ListName.text = record.listname;
        Author.text = record.authors;
        TotalPeople.text = $"{record.refcount}人已加入";
        image.color = myListColor;

        if (record.isref)
            image.color = myRefListColor;
        else
            image.color = myListColor;
    }

    void RecordDecorate<JRealList>.refreshUI(JRealList record)
    {
        ListName.text = record.listname;
        Author.text = record.userid;
        TotalPeople.text = $"{record.refcount}人已加入";

        if (record.ismyref)
            image.color = myRefListColor;
        else if (record.ismylist)
            image.color = myListColor;
        else
            image.color = listColor;
    }
}
