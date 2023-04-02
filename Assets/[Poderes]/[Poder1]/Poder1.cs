using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poder1 : MonoBehaviour
{ 
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float poder1Cooldown;
    private float nextTime=0;
    void Update()
    {
         if(Time.time > nextTime)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                nextTime = Time.time+poder1Cooldown;
            }
        }
    }
}
