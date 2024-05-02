using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 50;
    public TankBaseObj fatherObj;
    //子弹消亡特效
    public GameObject effObj;
    public int addForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        this.GetComponent<Rigidbody>().AddForce(Vector3.down * addForce);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Cube")||
            other.CompareTag("Player")&&fatherObj.CompareTag("Monster")||
            other.CompareTag("Monster")&&fatherObj.CompareTag("Player"))
        {
            TankBaseObj tank = other.GetComponent<TankBaseObj>();
            if (tank != null)
            {
                tank.Wound(fatherObj);
            }
            if (effObj != null)
            {
                GameObject eff = Instantiate(effObj, this.transform.position, this.transform.rotation);
                AudioSource audio = eff.GetComponent<AudioSource>();
                audio.volume = GameDataMgr.Instance.musicData.soundValue;
                audio.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            }
            Destroy(this.gameObject);
        }
        
    }
    public void SetFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }
}
