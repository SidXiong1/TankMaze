using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePannel<BeginPanel>
{
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnList;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        btnBegin.clickEvent += () =>
        {
            //加载游戏场景
            SceneManager.LoadScene("GameScene");
        };
        btnSetting.clickEvent += () =>
        {
            //打开设置面板
            SettingPannel.Instance.ShowMe();
            HideMe();
        };
        btnQuit.clickEvent += () =>
        {
            //退出游戏
            Application.Quit();
        };
        btnList.clickEvent += () =>
        {
            //打开排行榜面板
            ListPanel.Instance.ShowMe();
            HideMe();
        };
        //HideMe();
        //print("ok");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
