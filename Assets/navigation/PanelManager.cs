using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public string userid = "Marc";
    int listid = 0;
    bool ismyList;
    [SerializeField] ListBuilder listBuilder;
    [SerializeField] MusicBuilder musicBuilder;

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
    [SerializeField]
    GameObject MusicRepoListMusicPanel;

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

        //熱門音樂
        loadTool.startFetchData(
            new JQueryMusic { userid = userid, islimit = true },
            "http://localhost:3001/Musics/get_all_public_musics/",
            (json) => {
                musicBuilder.updateMusic5(JsonUtility.FromJson<JsonM<JMusic>>(json));
            });

        //熱門清單
        loadTool.startFetchData(
            new JQueryList { userid = userid, islimit = true },
            "http://localhost:3001/Lists/get_all_list_not_ref/",
            (json) => {
                listBuilder.updateList5(JsonUtility.FromJson<JsonM<JRealList>>(json));
            });
    }

    //我的清單
    public void setActiveMyListPanel()
    {
        nowPanel.SetActive(false);
        (nowPanel = MyListPanel).SetActive(true);
        animator.SetInteger(str_memoryMyList, 1);

        loadTool.startFetchData(
            new JQueryList { userid = userid },
            "http://localhost:3001/Lists/get_all_list_of_this_user/",
            (json) => {
                listBuilder.updateMyList(JsonUtility.FromJson<JsonM<JMyList>>(json));
            });

    }

    //全部樂曲
    public void setActiveAllMusicPanel()
    {
        nowPanel.SetActive(false);
        (nowPanel = AllMusicPanel).SetActive(true);
        animator.SetInteger(str_memoryMusicRepo, 2);

        //熱門音樂
        loadTool.startFetchData(
            new JQueryMusic { userid = userid, islimit = false },
            "http://localhost:3001/Musics/get_all_public_musics/",
            (json) => {
                musicBuilder.updateMusic(JsonUtility.FromJson<JsonM<JMusic>>(json));
            });
    }

    //全部清單
    public void setActiveAllListPanel()
    {
        nowPanel.SetActive(false);
        (nowPanel = AllListPanel).SetActive(true);
        animator.SetInteger(str_memoryMusicRepo, 3);

        loadTool.startFetchData(
            new JQueryList { userid = userid, islimit = false },
            "http://localhost:3001/Lists/get_all_list_not_ref/",
            (json) => {
                listBuilder.updateList(JsonUtility.FromJson<JsonM<JRealList>>(json));
            });
    }

    //音樂庫/清單樂曲
    public void setActiveMusicRepoListMusicPanel()
    {
        nowPanel.SetActive(false);
        (nowPanel = MusicRepoListMusicPanel).SetActive(true);
        animator.SetInteger(str_memoryMusicRepo, 4);

        select(true);
    }

    //我的清單/清單樂曲
    public void setActiveMyListListMusicPanel()
    {
        nowPanel.SetActive(false);
        (nowPanel = ListMusicPanel).SetActive(true);
        animator.SetInteger(str_memoryMyList, 2);

        select(false);
    }

    void select(bool isMusicRepo)
    {
        if (ismyList) showMyListMusic(isMusicRepo);
        else showListMusic(isMusicRepo);
    }

    void showListMusic(bool isMusicRepo)
    {
        loadTool.startFetchData(
            new JQueryListMusic { userid = userid, listid = listid },
            "http://localhost:3001/Musics/get_list_music_by_viewer/",
            (json) => {
                musicBuilder.updateListMusic(JsonUtility.FromJson<JsonM<JListMusic>>(json), isMusicRepo);
            });
    }

    void showMyListMusic(bool isMusicRepo)
    {
        loadTool.startFetchData(
            new JQueryMyListMusic { listid = listid },
            "http://localhost:3001/Musics/get_list_music_by_owner/",
            (json) => {
                musicBuilder.updateMyListMusic(JsonUtility.FromJson<JsonM<JMyListMusic>>(json), isMusicRepo);
            });
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

    public void gotoListMusic(int listid, bool ismyList = false)
    {
        this.listid = listid;
        this.ismyList = ismyList;
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
