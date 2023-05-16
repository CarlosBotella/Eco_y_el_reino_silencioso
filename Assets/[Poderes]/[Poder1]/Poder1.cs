using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poder1 : MonoBehaviour
{ 
    public float poder1Cooldown;
    public float range;
    private float nextTime=0;
    public float damage;
    AttributesEnemies attributesEnemies;

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
                    Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
                    foreach (var hitCollider in hitColliders)
                    {
                        if(hitCollider.transform.gameObject.layer == 7)
                        {
                            attributesEnemies = hitCollider.gameObject.GetComponent<AttributesEnemies>();
                            attributesEnemies.TakeDamage(damage);
                            attributesEnemies.speed=0;
                        } 
                    }
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
