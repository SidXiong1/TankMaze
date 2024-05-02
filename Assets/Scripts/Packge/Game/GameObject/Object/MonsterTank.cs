using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTank : TankBaseObj
{
    private Transform targetPos;
    public Transform[] randomPos;
    public Transform targetLookAt;
    public float fireDistance = 10;
    public float fireOffsetTime = 1;
    public int bulletNum = 0;
    private int nowBulletNum = 0;
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
            BulletObj buScript = bu.GetComponent<BulletObj>();
            buScript.SetFather(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.moveSpeed = 5;
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(targetPos);
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if(Vector3.Distance(this.transform.position, targetPos.position) < 0.05f)
        {
            RandomPos();
        }
        if (targetLookAt != null)
        {
            tankHead.LookAt(targetLookAt);
            if (Vector3.Distance(this.transform.position, targetLookAt.position) < fireDistance)
            {
                nowTime += Time.deltaTime;
                if (nowTime > fireOffsetTime)
                {
                    if (fireOffsetTime > 1)
                    {
                        fireOffsetTime -= 4;
                    }
                    Fire();
                    nowBulletNum++;
                    if (nowBulletNum >= bulletNum)
                    {
                        fireOffsetTime += 4;
                        nowBulletNum = 0;
                    }
                    nowTime = 0;
                }
            }
        }
    }
    private void RandomPos()
    {
        if (randomPos.Length == 0)
        {
            return;
        }
        targetPos = randomPos[Random.Range(0, randomPos.Length)];
    }
    public override void Dead()
    {
        base.Dead();
        GamePanel.Instance.AddScore(10);
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
