using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPanel : BasePannel<ListPanel>
{
    public CustomGUIButton btnClose;

    private List<CustomGUILable> labName = new List<CustomGUILable>();
    private List<CustomGUILable> labScore = new List<CustomGUILable>();
    private List<CustomGUILable> labTime = new List<CustomGUILable>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <= 8; i++)
        {
            labName.Add(this.transform.Find("LabName/labName" + i).GetComponent<CustomGUILable>());
            labScore.Add(this.transform.Find("LabScore/labScore" + i).GetComponent<CustomGUILable>());
            labTime.Add(this.transform.Find("LabTime/labTime" + i).GetComponent<CustomGUILable>());
        }
        //print(labList.Count);
        //print(labName.Count);
        //print(labScore.Count);
        //print(labTime.Count);

        btnClose.clickEvent += () =>
        {
            BeginPanel.Instance.ShowMe();
            HideMe();
        };

        //GameDataMgr.Instance.AddList("测试数据", 100, 8432);

        HideMe();
    }
    public override void ShowMe()
    {
        base.ShowMe();
        UpdataPanelInfo();
    }
    public void UpdataPanelInfo()
    {
        //处理排行榜信息更新
        ListList listList = GameDataMgr.Instance.listList;
        for(int i = 0; i < listList.infos.Count; i++)
        {
            labName[i].content.text = listList.infos[i].name;
            labScore[i].content.text = listList.infos[i].score.ToString();
            int time = listList.infos[i].time;
            labTime[i].content.text = "";
            if (time / 3600 > 0)
            {
                labTime[i].content.text = time / 3600 + "时";
            }
            if (time % 3600 / 60 > 0 || labTime[i].content.text != "")
            {
                labTime[i].content.text += time % 3600 / 60 + "分";
            }
            labTime[i].content.text += time % 60 + "秒";
        }
    }
}
