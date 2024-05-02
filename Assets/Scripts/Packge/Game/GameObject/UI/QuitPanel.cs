using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePannel<QuitPanel>
{
    public CustomGUIButton btnClose;
    public CustomGUIButton btnYes;
    public CustomGUIButton btnNo;
    // Start is called before the first frame update
    void Start()
    {
        btnClose.clickEvent += () =>
        {
            Time.timeScale = 1;
            HideMe();
            GamePanel.Instance.ShowMe();
        };
        btnYes.clickEvent += () =>
        {
            Time.timeScale = 1;
            //退出到主界面
            SceneManager.LoadScene("BeginScene");
        };
        btnNo.clickEvent += () =>
        {
            Time.timeScale = 1;
            HideMe();
            GamePanel.Instance.ShowMe();
        };
        HideMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
