using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OneList : MonoBehaviour
{
    [SerializeField] RectTransform rect;
    [SerializeField] Text ListNameText;
    [SerializeField] Text AuthorText;
    [SerializeField] Text TotalPeopleText;
    [SerializeField] Image image;

    static Color myListColor = new Color(221.0f / 255, 252.0f / 255, 255.0f / 255);//水藍
    static Color myRefListColor = new Color(212.0f / 255, 240.0f / 255, 194.0f / 255);//淡綠
    static Color listColor = new Color(255.0f / 255, 201.0f / 255, 201.0f / 255);//粉紅

    public void refreshMyList(JMyList record) {
        ListNameText.text = record.listname;
        AuthorText.text = record.authors;
        TotalPeopleText.text = $"{record.refcount}人已加入";
        image.color = myListColor;

        if (record.isref)
            image.color = myRefListColor;
        else
            image.color = myListColor;
    }

    public void refreshList(JRealList record)
    {
        ListNameText.text = record.listname;
        AuthorText.text = record.userid;
        TotalPeopleText.text = $"{record.refcount}人已加入";

        if (record.ismyref)
            image.color = myRefListColor;
        else if (record.ismylist)
            image.color = myListColor;
        else
            image.color = listColor;
    }
}
