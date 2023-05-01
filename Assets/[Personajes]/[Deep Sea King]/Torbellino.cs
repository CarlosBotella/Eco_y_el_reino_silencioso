using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torbellino : MonoBehaviour
{
public float rango;
private bool Alert;
public LayerMask playermask;
public float timeTorbellino;
public float pullforce;
Rigidbody player;
Transform playert;
GameObject Eco;
Attibute attibute;
public Transform centerTorbellino;
PlayerController playerController;

public float tornadoattackcooldown;
private float nextTime = 0;
public float dmg;
void Start()
{
    Eco = GameObject.FindWithTag("Player");
    playert = Eco.transform;
    playerController = Eco.GetComponent<PlayerController>();
    attibute = Eco.GetComponent<Attibute>();
}
private void Awake() {
    Destroy(gameObject,timeTorbellino); 
}
 private void Update() {
    Alert = Physics.CheckSphere(transform.position, rango, playermask);
        if(Alert == true)
        {
            StartCoroutine(Pull());
        }
 }
  private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rango);
    } 

    IEnumerator Pull() {
        Vector3 ForeDir = centerTorbellino.position - playert.position;
        playerController.player.Move(ForeDir.normalized*pullforce*Time.deltaTime);
        yield return null;
    }

     private void OnTriggerStay(Collider other) {
         if(other.CompareTag("Player"))
        {
            if(Time.time > nextTime)
            {
                attibute.TakeDamage(dmg);
                nextTime=Time.time+tornadoattackcooldown;
            }
        }
    }
}
