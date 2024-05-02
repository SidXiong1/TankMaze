using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePannel<GamePanel>
{
    public CustomGUILable labScore;
    public CustomGUILable labTime;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnSetting;
    public CustomGUITexture texHP;
    public CustomGUILable labHP;
    private string strHP;

    [HideInInspector]
    public int nowScore = 0;
    public float hpw = 600;
    [HideInInspector]
    public float nowTime = 0;
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        btnSetting.clickEvent += () =>
        {
            //游戏设置
            Time.timeScale = 0;
            SettingPannel.Instance.ShowMe();
            HideMe();
        };
        btnQuit.clickEvent += () =>
        {
            //游戏退出，附带确定界面
            Time.timeScale = 0;
            QuitPanel.Instance.ShowMe();
            HideMe();
        };

            //AddScore(100);
            //UpdataHP(600, 300);
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;

        time = (int)nowTime;
        labTime.content.text = "";
        if (time / 3600 > 0)
        {
            labTime.content.text = time / 3600 + "时";
        }
        if (time % 3600 / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += time % 3600 / 60 + "分";
        }
        labTime.content.text += time % 60 + "秒";
    }
    public void AddScore(int value)
    {
        nowScore += value;
        labScore.content.text = nowScore.ToString();
    }
    public void UpdataHP(int maxHP,int HP)
    {
        texHP.guiPos.width = (float)HP / maxHP * hpw;
        strHP = HP.ToString() + "/" + maxHP;
        labHP.content.text = strHP;
    }
}
