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
    private float speedr;

    private void Start()
    {
        player = GetComponent<CharacterController>();
        speedr = playerSpeed;

        // Bloquear el cursor al inicio
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Buscar el objeto del men� por su nombre
        GameObject menuObject = GameObject.Find("EscMenu");

        if (menuObject != null)
        {
            // Detectar si el men� est� activo o no
            bool isMenuActive = menuObject.activeSelf;

            // Ajustar el bloqueo del cursor seg�n el estado del men�
            if (isMenuActive)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            // Detectar si se ha presionado la tecla "Escape" para abrir/cerrar el men�
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuObject.SetActive(!isMenuActive);
            }
        }

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
        if(player.isGrounded && Input.GetButtonDown("Jump")) 
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
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

}
