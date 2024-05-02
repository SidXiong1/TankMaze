using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    public int atk;
    public int def;
    public int maxHP;
    public int HP;

    public float moveSpeed = 10;
    public float rotateSpeed = 100;
    public float headRotateSpeed = 100;

    //炮台
    public Transform tankHead;
    /// <summary>
    /// 死亡特效对象
    /// </summary>
    public GameObject deadEff;

    public abstract void Fire();

    public virtual void Wound(TankBaseObj other)
    {
        int damage = other.atk - this.def;
        if (damage <= 0)
        {
            return;
        }
        else
        {
            this.HP -= damage;
        }
        if (this.HP <= 0)
        {
            this.HP = 0;
            this.Dead();
        }
    }
    public virtual void Dead()
    {
        Destroy(this.gameObject);
        if (deadEff != null)
        {
            GameObject gameObject = Instantiate(deadEff, this.transform.position,this.transform.rotation);
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = GameDataMgr.Instance.musicData.isOpenSound;
            audioSource.Play();
        }
    }
}
