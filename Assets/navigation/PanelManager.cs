using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] ListBuilder listBuilder;

    LoadJson loadTool;
    Animator animator;

    GameObject nowPanel;

    //All Tabe
    [SerializeField]
    GameObject MusicRepoPanel;
    [SerializeField]
    GameObject MyListPanel;

    //Tab 1子項目
    [SerializeField]
    GameObject AllMusicPanel;
    [SerializeField]
    GameObject AllListPanel;

    //Tab 1
    //Tab 2子項目
    [SerializeField]
    GameObject ListMusicPanel;

    [SerializeField]
    GameObject PlayMusicPanel;

    string str_target = "target";
    string str_memoryMusicRepo = "memoryMusicRepo";
    string str_memoryMyList = "memoryMyList";
    string str_back = "back";
    string str_gotoAllMusic = "gotoAllMusic";
    string str_gotoAllList = "gotoAllList";
    string str_gotoListMusic = "gotoListMusic";
    string str_goTop = "goTop";

    void initAnimator()
    {
        animator = GetComponent<Animator>();
        Debug.Assert(animator != null);

        animator.GetBehaviour<MyListTabMyList>().panelManager = this;
        animator.GetBehaviour<MyListTabListMusic>().panelManager = this;

        animator.GetBehaviour<MusicRepoTabMusicRepo>().panelManager = this;
        animator.GetBehaviour<MusicRepoTabAllMusic>().panelManager = this;
        animator.GetBehaviour<MusicRepoTabAllList>().panelManager = this;
        animator.GetBehaviour<MusicRepoTabListMusic>().panelManager = this;

        nowPanel = MusicRepoPanel;
    }

    // Use this for initialization
    void Awake()
    {
        initAnimator();

        loadTool = GetComponent<LoadJson>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //音樂庫
    public void setActiveMusicRepoPanel()
    {
        nowPanel.SetActive(false);
        (nowPanel = MusicRepoPanel).SetActive(true);
        animator.SetInteger(str_memoryMusicRepo, 1);
    }

    //我的清單
    public void setActiveMyListPanel()
    {
        nowPanel.SetActive(false);
        (nowPanel = MyListPanel).SetActive(true);
        animator.SetInteger(str_memoryMyList, 1);

        loadTool.startFetchData(
            new JQueryList { userid = "Marc" },
            "http://localhost:3001/Lists/get_all_list_of_this_user/",
            (json)=> {
                listBuilder.updateContainer(JsonUtility.FromJson<JsonM<JList>>(json));
            });

    }

    //全部樂曲
    public void setActiveAllMusicPanel()
    {
        nowPanel.SetActive(false);
        (nowPanel = AllMusicPanel).SetActive(true);
        animator.SetInteger(str_memoryMusicRepo, 2);
    }

    //全部清單
    public void setActiveAllListPanel()
    {
        nowPanel.SetActive(false);
        (nowPanel = AllListPanel).SetActive(true);
        animator.SetInteger(str_memoryMusicRepo, 3);
    }

    //音樂庫/清單樂曲
    public void setActiveMusicRepoListMusicPanel()
    {
        nowPanel.SetActive(false);
        (nowPanel = ListMusicPanel).SetActive(true);
        animator.SetInteger(str_memoryMusicRepo, 4);
    }

    //我的清單/清單樂曲
    public void setActiveMyListListMusicPanel()
    {
        nowPanel.SetActive(false);
        (nowPanel = ListMusicPanel).SetActive(true);
        animator.SetInteger(str_memoryMyList, 2);
    }

    public void goBack()
    {
        animator.SetTrigger(str_back);
    }

    public void gotoAllMusic()
    {
        animator.SetTrigger(str_gotoAllMusic);
    }

    public void gotoAllList()
    {
        animator.SetTrigger(str_gotoAllList);
    }

    public void gotoListMusic()
    {
        animator.SetTrigger(str_gotoListMusic);
    }

    public void Tab1()
    {
        animator.SetInteger(str_target, 1);
        animator.SetTrigger(str_goTop);
    }

    public void Tab2()
    {
        animator.SetInteger(str_target, 2);
        animator.SetTrigger(str_goTop);
    }

    public void Tab3()
    {
        animator.SetInteger(str_target, 3);
        animator.SetTrigger(str_goTop);
    }
}
