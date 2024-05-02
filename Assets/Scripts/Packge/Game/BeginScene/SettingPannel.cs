using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPannel : BasePannel<SettingPannel>
{
    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;

    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;

    public CustomGUIButton btnClose;
    // Start is called before the first frame update
    void Start()
    {
        sliderMusic.sliderChange += (value) => GameDataMgr.Instance.ChangeMusicValue(value);
        sliderSound.sliderChange += (value) => GameDataMgr.Instance.ChangeSoundValue(value);
        togMusic.OnValueChange += (value) => GameDataMgr.Instance.OpenOrCloseMusic(value);
        togSound.OnValueChange += (value) => GameDataMgr.Instance.OpenOrCloseSound(value);
        btnClose.clickEvent += ()=>{
            //关闭按钮
            if (SceneManager.GetActiveScene().name == "BeginScene")
            {
                BeginPanel.Instance.ShowMe();
            }else if(SceneManager.GetActiveScene().name == "GameScene")
            {
                GamePanel.Instance.ShowMe();
                Time.timeScale = 1;
            }
            HideMe();
        };
        HideMe();
        //this.gameObject.SetActive(false);
    }
    private void UpdataPanelInfo()
    {
        MusicData musicData = GameDataMgr.Instance.musicData;

        togMusic.isSel = musicData.isOpenMusic;
        togSound.isSel = musicData.isOpenSound;
        sliderMusic.nowValue = musicData.musicValue;
        sliderSound.nowValue = musicData.soundValue;
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdataPanelInfo();
    }
}
