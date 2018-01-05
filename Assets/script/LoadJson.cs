using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadJson : MonoBehaviour
{
    //這裡直接用callBack接收匿名函式更簡捷
    //用event反而要列出一堆
    public delegate void onJsonLoadCallBack(string json);
    private IEnumerator handle;
    public void startFetchData(object query, string url, onJsonLoadCallBack todoFun)
    {
        handle = fetchData(query, url,todoFun);
        StartCoroutine(handle);
    }

    // Use this for initialization
    IEnumerator fetchData(object query, string url, onJsonLoadCallBack todoFun)
    {
        var headers = new Dictionary<string,string>();
        headers.Add("Content-Type", "application/json");
        string data = JsonUtility.ToJson(query);
        
        byte[] bs = System.Text.UTF8Encoding.UTF8.GetBytes(data);

        using (WWW www = new WWW(url, bs,headers))
        {
            yield return www;

            print("finish");
            todoFun(www.text);
        }
    }
}

[Serializable]
public class JsonM<Type>
{
    public List<Type> data;
}

public class JsonS<Type>
{
    public Type data;
}


[Serializable]
class JQueryList
{
    public string userid;
    public bool islimit;
}


[Serializable]
public class JMyList
{
    public int id;
    public string listname;
    public string description;
    public string createtime;
    public bool isref;
    public int refcount;
    public string authors;
}

[Serializable]
public class JRealList
{
    public int id;
    public string listname;
    public string description;
    public string createtime;
    public string userid;
    public int ownercount;
    public int refcount;
    public bool ismylist;
    public bool ismyref;
}

[Serializable]
class JQueryListMusic
{
    public string userid;
    public int listid;
}

[Serializable]
public class JListMusic
{
    public int id;
    public string musicname;
    public string description;
    public int voterscount;
    public int averagestart;
    public string createtime;
    public int ownercount;
    public int refcount;

    public bool ismymusic;
    public bool ismyref;
    public string authors;

    //需要多1個欄位:記錄user是否已經ref過
}

[Serializable]
class JQueryMusic
{
    public string userid;
    public bool islimit;
}

[Serializable]
public class JMusic
{
    public int id;
    public string musicname;
    public string description;
    public string createtime;
    public int ownercount;
    public int refcount;

    public int averagestart;
    public int voterscount;

    public bool ismysong;
    public string authors;

    //需要多1個欄位:記錄user是否已經ref過
}

