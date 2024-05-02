using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr 
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance { get => instance; }

    public MusicData musicData;
    public ListList listList;
    
    private GameDataMgr()
    {
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData), "Music") as MusicData;
        if (!musicData.notFirst)
        {
            musicData.musicValue = 1;
            musicData.soundValue = 1;
            musicData.isOpenMusic = true;
            musicData.isOpenSound = true;
            musicData.notFirst = true;

            PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
        }

        listList = PlayerPrefsDataMgr.Instance.LoadData(typeof(ListList), "List") as ListList;
    }
    public void AddList(string name, int score, int time)
    {
        listList.infos.Add(new ListInfo(name, score, time));
        listList.infos.Sort((a, b) => { return a.time > b.time ? 1 : -1; });
        for(int i = listList.infos.Count; i >= 10; i--)
        {
            listList.infos.RemoveAt(i);
        }
        PlayerPrefsDataMgr.Instance.SaveDate(listList, "List");

    }

    public void OpenOrCloseMusic(bool isOpen)
    {
        musicData.isOpenMusic = isOpen;
        PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
        BKMusic.Instance.ChangeOpen(isOpen);
    }
    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;
        PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
    }
    public void ChangeMusicValue(float value)
    {
        musicData.musicValue = value;
        PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
        BKMusic.Instance.ChangeValue(value);
    }
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
    }
}
