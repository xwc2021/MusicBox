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
class JsonM<Type>
{
    public List<Type> data;
}

class JsonS<Type>
{
    public Type data;
}


[Serializable]
class JQueryList
{
    public string userid;
}


[Serializable]
class JList
{
    public int id;
    public string listname;
    public string description;
    public string createtime;
    public bool isref;
}

[Serializable]
class JQueryMusic
{
    public int listid;
}

[Serializable]
class JMusic
{
    public int listid;
    public int musicid;
    public string musicname;
    public string description;
    public int voterscount;
    public int averagestart;
    public int ownercount;
    public int refcount;
    public string createtime;
    public bool isref;
}


