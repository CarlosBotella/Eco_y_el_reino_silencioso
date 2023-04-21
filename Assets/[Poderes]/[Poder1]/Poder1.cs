using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poder1 : MonoBehaviour
{ 
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float poder1Cooldown;
    private float nextTime=0;

    public Image poder1;
    public Image cpoder1;


    private void Start() {
        cpoder1.enabled = enabled;
        poder1.enabled = enabled;
        poder1.fillAmount = 1;
    }
    void Update()
    {
         if(Time.time > nextTime)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                nextTime = Time.time+poder1Cooldown;
                poder1.fillAmount= 0;
            }
        }
        else
        {
            poder1.fillAmount += 1/poder1Cooldown * Time.deltaTime;
            if(poder1.fillAmount >= 1)
            {
                poder1.fillAmount = 1;
            }
        }
       
    }

}
