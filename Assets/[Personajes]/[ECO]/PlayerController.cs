using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;
    public CharacterController player;
    public float playerSpeed = 10;
    public Vector3 movePlayer;
    public float gravity= 9.81f;
    private float fallVelocity;
    public float jumpForce = 6;

    public Camera mainCamera;
    private Vector3 camFroward;
    private Vector3 camRight;


    private void Start()
    {
        player=GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0 , verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput,1);

        camDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camFroward;
        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);
        
        setGravity();
        playerSkills();
        

        player.Move(movePlayer * Time.deltaTime);
        

    }

    public void camDirection()
    {
        camFroward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;
        
        camFroward.y=0; camRight.y=0;

        camFroward = camFroward.normalized;
        camRight = camRight.normalized;
    }

    public void setGravity()
    {
        if(player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;  
            movePlayer.y = fallVelocity;
        }
    }

    public void playerSkills()
    {
        // if(player.isGrounded && Input.GetButtonDown("Jump")) 
        if(Input.GetButtonDown("Jump")) 
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
    }

}
