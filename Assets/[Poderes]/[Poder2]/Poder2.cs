using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poder2 : MonoBehaviour
{
    public float poder2Cooldown;
    public float range;
    private float nextTime = 0;
    public float damage;
    AttributesEnemies attributesEnemies;

    public Image poder2;
    public Image cpoder2;


    private void Start()
    {
        cpoder2.enabled = enabled;
        poder2.enabled = enabled;
        poder2.fillAmount = 1;
    }
    void Update()
    {
        if (Time.time > nextTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.transform.gameObject.layer == 7)
                    {
                        attributesEnemies = hitCollider.gameObject.GetComponent<AttributesEnemies>();
                        attributesEnemies.TakeDamage(damage);
                    }
                }
                nextTime = Time.time + poder2Cooldown;
                poder2.fillAmount = 0;
            }
        }
        else
        {
            poder2.fillAmount += 1 / poder2Cooldown * Time.deltaTime;
            if (poder2.fillAmount >= 1)
            {
                poder2.fillAmount = 1;
            }
        }

    }
}
