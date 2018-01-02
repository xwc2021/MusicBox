using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OneList : MonoBehaviour,RecordDecorate<JMyList>,RecordDecorate<JRealList>
{
    [SerializeField] PanelManager panelManager;

    [SerializeField] RectTransform rect;
    [SerializeField] Text ListName;
    [SerializeField] Text Author;
    [SerializeField] Text TotalPeople;
    [SerializeField] Image image;
    int listid;
    bool isMyList;
    

    void RecordDecorate<JMyList>.refreshUI(JMyList record)
    {
        listid = record.id;
        ListName.text = record.listname;
        Author.text = record.authors;
        TotalPeople.text = $"{record.refcount}人已加入";

        image.color = record.isref ? Style.myRefColor : Style.myColor;
        isMyList = !record.isref;
    }

    void RecordDecorate<JRealList>.refreshUI(JRealList record)
    {
        listid = record.id;
        ListName.text = record.listname;
        Author.text = record.userid;
        TotalPeople.text = $"{record.refcount}人已加入";

        if (record.ismyref)
            image.color = Style.myRefColor;
        else if (record.ismylist)
            image.color = Style.myColor;
        else
            image.color = Style.otherColor;

        isMyList = record.ismylist;
    }

    public void gotoListMusic()
    {
        print(isMyList);
        panelManager.gotoListMusic(listid, isMyList);
    }
}
