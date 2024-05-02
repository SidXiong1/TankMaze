using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    public WeaponObj nowWeapon;
    public Transform weaponPos;
    public override void Fire()
    {
        if (nowWeapon != null)
        {
            nowWeapon.Fire();
        }
    }
    public override void Dead()
    {
        //base.Dead();
        Time.timeScale = 0;
        LosePanel.Instance.ShowMe();
    }
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        GamePanel.Instance.UpdataHP(this.maxHP, this.HP);
    }

    // Start is called before the first frame update
    void Start()
    {
        GamePanel.Instance.UpdataHP(maxHP, HP);
    }

    // Update is called once per frame
    void Update()
    {
        //前后移动
        this.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime);
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * rotateSpeed * Time.deltaTime);

        //tankHead.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headRotateSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void ChangeWeapon(GameObject obj)
    {
        if (nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
        }
        GameObject weapon = Instantiate(obj, weaponPos,false);
        nowWeapon = weapon.GetComponent<WeaponObj>();
        nowWeapon.SetFather(this);
    }
}
