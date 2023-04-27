using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlayer : MonoBehaviour
{
    public float dashSpeed = 3;
    public float dashTime = 0.25f;
    PlayerController playercontroller;
    public float dashCooldown = 0;
    private float nextTime=0;
    

    // Start is called before the first frame update
    void Start()
    {
        playercontroller = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextTime)
        {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
            nextTime = Time.time+dashCooldown;
           
        }
        }
    }
    
    IEnumerator Dash()
    {
        float startTime=Time.time;
        while(Time.time < startTime+ dashTime )
        {
            playercontroller.player.Move(playercontroller.movePlayer * dashSpeed * Time.deltaTime);
            yield return null;
        }
    }

   
}
