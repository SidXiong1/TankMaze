using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListInfo 
{
    public string name;
    public int score;
    public int time;
    

    public ListInfo()
    {

    }
    public ListInfo(string name,int score,int time)
    {
        this.name = name;
        this.score = score;
        this.time = time;
    }
}
public class ListList
{
    public List<ListInfo> infos;
}
