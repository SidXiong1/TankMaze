using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : BasePannel<LosePanel>
{
    public CustomGUIButton btnReturn;
    public CustomGUIButton btnRetry;
    // Start is called before the first frame update
    void Start()
    {
        btnReturn.clickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        };
        btnRetry.clickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
        };
        HideMe();
    }

}
