using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankBaseObj
{
    public float intervalTime = 2;
    private float nowTime = 0;
    public Transform[] shootPos;
    public GameObject bullet;

    public Texture texHP;
    public Texture texMaxHP;
    private Rect recHP;
    private Rect recMaxHP;
    public float showTime;

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject bu = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            BulletObj buScrpit = bu.GetComponent<BulletObj>();
            buScrpit.SetFather(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        if (nowTime > intervalTime)
        {
            Fire();
            nowTime = 0;
        }
    }

    private void OnGUI()
    {
        if (showTime > 0)
        {
            showTime -= Time.deltaTime;

            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //int distance = (int)screenPos.z % 5;
            screenPos.y = Screen.height - screenPos.y;

            screenPos.x -= 50;
            screenPos.y -= 50;

            recMaxHP.x = screenPos.x;
            recMaxHP.y = screenPos.y;
            recMaxHP.width = 100;
            recMaxHP.height = 15;
            GUI.DrawTexture(recMaxHP, texMaxHP);

            recHP.x = screenPos.x;
            recHP.y = screenPos.y;
            recHP.width = (float)HP / maxHP * 100;
            recHP.height = 15;
            GUI.DrawTexture(recHP, texHP);
        }

    }
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        showTime = 1;
    }
}
