using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReword : MonoBehaviour
{
    //随机武器对象
    public GameObject[] weaponObj;
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int index = Random.Range(0, weaponObj.Length);
            PlayerObj player = other.GetComponent<PlayerObj>();
            player.ChangeWeapon(weaponObj[index]);

            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            AudioSource audio = eff.GetComponent<AudioSource>();
            audio.volume = GameDataMgr.Instance.musicData.soundValue;
            audio.mute = !GameDataMgr.Instance.musicData.isOpenSound;

            Destroy(this.gameObject);
            
        }
    }
}
