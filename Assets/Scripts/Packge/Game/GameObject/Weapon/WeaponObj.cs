using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    //用于实例化子弹对象
    public GameObject bullet;
    //子弹发射位置
    public Transform[] shootPos;
    public TankBaseObj fatherObj;

    public void SetFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }

    public void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject bu = Instantiate(bullet, shootPos[i].position,shootPos[i].rotation);
            //print("ok");
            BulletObj bulletObj = bu.GetComponent<BulletObj>();
            bulletObj.SetFather(fatherObj);
        }
    }
}
