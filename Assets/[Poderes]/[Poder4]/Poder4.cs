using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poder4 : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float poder4Cooldown;
    private float nextTime=0;

    public Image poder4;
    public Image cpoder4;
    // Start is called before the first frame update
    void Start()
    {
        cpoder4.enabled = enabled;
        poder4.enabled = enabled;
        poder4.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
         if(Time.time > nextTime)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                nextTime = Time.time+poder4Cooldown;
                poder4.fillAmount= 0;
            }
        }
        else
        {
            poder4.fillAmount += 1/poder4Cooldown * Time.deltaTime;
            if(poder4.fillAmount >= 1)
            {
                poder4.fillAmount = 1;
            }
        }
    }
}
