using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poder4Bullet : MonoBehaviour
{
    public float dmg;
    public float life;
    AttributesEnemies attributesEnemies;
    private bool hasCollided = false;
   
   private void Awake() {
    Destroy(gameObject,life);
   }
   private void OnCollisionEnter(Collision other) {
    if (hasCollided) return;
    if(other.gameObject.layer==7)
    {
        attributesEnemies = other.gameObject.GetComponent<AttributesEnemies>();
        attributesEnemies.TakeDamage(dmg);
    }
    hasCollided = true;
    Destroy(gameObject);
   }
}
