using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poder5 : MonoBehaviour
{
    public float dashSpeed = 3;
    public float dashTime = 0.25f;
    PlayerController playercontroller;
    public float dashCooldown;
    private float nextTime=0;
    AttributesEnemies attributesEnemies;
 
    private float speed;
    public Image poder5;
    public Image cpoder5;

    

    // Start is called before the first frame update
    void Start()
    {
        playercontroller = GetComponent<PlayerController>();
        speed= playercontroller.playerSpeed;
        cpoder5.enabled = enabled;
        poder5.enabled = enabled;
        poder5.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.time>nextTime)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(Dash());
                nextTime = Time.time+dashCooldown;
                poder5.fillAmount= 0;   
            }
        }
        else
        {
            poder5.fillAmount += 1/dashCooldown * Time.deltaTime;
            if(poder5.fillAmount >= 1)
            {
                poder5.fillAmount = 1;
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
