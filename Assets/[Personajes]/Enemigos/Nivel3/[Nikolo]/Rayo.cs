using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayo : MonoBehaviour
{
    public float damage = 40;
    private Attibute player1;
    private PlayerController player;
     GameObject Eco;
     public float life;
    // Start is called before the first frame update
    void Start()
    {
        Eco = GameObject.FindWithTag("Player");
        player1 = Eco.GetComponent<Attibute>();
        player = Eco.GetComponent<PlayerController>();

    }
    void Awake() {
        Destroy(gameObject,life);
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other) {
      if(other.CompareTag("Player"))
        {
            player1.TakeDamage(damage);
            player.playerSpeed=0;
        }
        Destroy(gameObject,0.15f);
    }

}
