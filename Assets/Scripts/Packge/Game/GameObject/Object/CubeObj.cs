using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    public GameObject[] reword;
    public GameObject deadEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            int x = Random.Range(1, 101);
            if (x <= 25)
            {
                int y = Random.Range(0, 5);
                Instantiate(reword[y], this.transform.position, this.transform.rotation);
            }
            GameObject obj = Instantiate(deadEff, this.transform.position, this.transform.rotation);
            AudioSource audio = obj.GetComponent<AudioSource>();
            audio.volume = GameDataMgr.Instance.musicData.soundValue;
            audio.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            Destroy(this.gameObject);
        }
        
    }
}
