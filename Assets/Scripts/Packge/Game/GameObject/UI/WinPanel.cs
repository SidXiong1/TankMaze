using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePannel<WinPanel>
{
    public CustomGUIInput inputInfo;
    public CustomGUIButton btnYes;
    // Start is called before the first frame update
    void Start()
    {
        btnYes.clickEvent += () =>
        {
            Time.timeScale = 1;
            GameDataMgr.Instance.AddList(inputInfo.content.text,
                GamePanel.Instance.nowScore,
                (int)GamePanel.Instance.nowTime);

            SceneManager.LoadScene("BeginScene");
        };
        HideMe();
    }
}
