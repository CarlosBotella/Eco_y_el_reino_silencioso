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
    public float fallVelocity;
    public float jumpForce = 6;

    public Camera mainCamera;
    private Vector3 camFroward;
    private Vector3 camRight;
    private float speedr;
    private Animator animator;
    private int targetAnimationHash;
    private float nextTime;
    public float nextJump;
    private float lastground;

    private void Start()
    {
        player = GetComponent<CharacterController>();
        speedr = playerSpeed;

        // Bloquear el cursor al inicio
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerSpeed == 0 )
        {
            StartCoroutine(Stun());
        }
         if(playerSpeed == 0.1f)
        {
            StartCoroutine(Sobrecarga());
        }
        if(playerSpeed == 7.5f)
        {
            StartCoroutine(Slow());
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("KncokBack"))
        {
           playerSpeed=0;           
        }
         if(animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {   
            if(player.isGrounded)
            {
                lastground = Time.time;
                nextTime = lastground + nextJump;
            }           
        }
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0 , verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput,1);

          if(playerInput.magnitude!=0)
          {
            animator.SetBool("Rumba",false);
          }

        animator.SetFloat("PlayerWalkVelocity",playerInput.magnitude * playerSpeed);

        camDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camFroward;
        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);
        
        setGravity();
        playerSkills();
        if(Input.GetKeyDown(KeyCode.B))
        {
            animator.SetBool("Rumba",true);
        }
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
            animator.SetFloat("PlayerVerticalVelocity",player.velocity.y);
        }
        animator.SetBool("IsGrounded",player.isGrounded);
    }

    public void playerSkills()
    {
        if(Time.time > nextTime)
        {
            if(player.isGrounded && Input.GetButtonDown("Jump")) 
            {  
                //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName)
                animator.SetFloat("PlayerWalkVelocity",0f);
                if(playerInput.magnitude == 0)
                {
                animator.SetFloat("Jumpf",0f);
                }
                else
                {
                    animator.SetFloat("Jumpf",1f);
                }
                animator.SetTrigger("Jump");
                fallVelocity = jumpForce;
                movePlayer.y = fallVelocity;
            }
        }
    }

    IEnumerator Stun()
    {
        yield return new WaitForSeconds(0.8f);
        playerSpeed = speedr*0.8f;
         yield return new WaitForSeconds(2.5f);
        playerSpeed=speedr;
    }

    IEnumerator Sobrecarga()
    {
        playerSpeed = 0f;
        yield return new WaitForSeconds(0.4f);
        playerSpeed=speedr*0.85f;
        yield return new WaitForSeconds(5f);
        playerSpeed=speedr;
    }

     IEnumerator Slow()
    {

        yield return new WaitForSeconds(2f);
        playerSpeed=speedr;
    }

    private void OnAnimatorMove() {
        
    }

}
