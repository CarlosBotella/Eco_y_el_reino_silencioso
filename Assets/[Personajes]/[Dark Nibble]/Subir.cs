using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subir: MonoBehaviour
{
     public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        playerController.fallVelocity = 10;
            playerController.movePlayer.y = playerController.fallVelocity;
        
    }
}
