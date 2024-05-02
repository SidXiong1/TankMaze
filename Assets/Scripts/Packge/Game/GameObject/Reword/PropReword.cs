using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PropType
{
    HP,
    MaxHP,
    Atk,
    Def,
}
public class PropReword : MonoBehaviour
{
    public int addAtk = 10;
    public int addDef = 1;
    public int addHP = 10;
    public int addMaxHP = 20;
    public E_PropType propType = E_PropType.Atk;
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerObj player = other.GetComponent<PlayerObj>();
            switch (propType)
            {
                case E_PropType.HP:
                    player.HP += addHP;
                    if (player.HP > player.maxHP)
                    {
                        player.HP = player.maxHP;
                    }
                    GamePanel.Instance.UpdataHP(player.maxHP, player.HP);
                    break;
                case E_PropType.MaxHP:
                    player.maxHP += addMaxHP;
                    GamePanel.Instance.UpdataHP(player.maxHP, player.HP);
                    break;
                case E_PropType.Atk:
                    player.atk += addAtk;
                    break;
                case E_PropType.Def:
                    player.def += addDef;
                    break;
                default:
                    break;
            }
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            AudioSource audio = eff.GetComponent<AudioSource>();
            audio.volume = GameDataMgr.Instance.musicData.soundValue;
            audio.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            Destroy(this.gameObject);
        }
    }
}
