using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce = 8f;

    //Vector3 movement;
    Animator anim;
    CharacterController playerController;
    Rigidbody playerRigidbody;
    //int floorMask;
    //float camRayLength = 100f;
    float verticalVelocity;
    float gravity = 15f;
    

    void Awake ()
    {
        //floorMask = LayerMask.GetMask ("Floor");
        anim = GetComponent<Animator> ();
        playerController = GetComponent<CharacterController>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // get the key input and change the animation
        //float h = Input.GetAxisRaw ("Horizontal");
        float h = CrossPlatformInputManager.GetAxis ("Horizontal");
        Animating(h);

        // jumping
        if (playerController.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            //if (Input.GetKeyDown(KeyCode.Space))
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // position change make player looks like moving
        Vector3 moveVector = Vector3.zero;

        moveVector.x = h * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = 0f;

        playerController.Move(moveVector * Time.deltaTime);

        Turning(h);
        
    }

    void Animating(float h)
    {
        bool walking = h != 0f && true;
        anim.SetBool ("IsWalking", walking);
    }

    void Turning(float h)
    {
        Vector3 lightRotation = Vector3.zero;
                

        lightRotation.x = -10f;
        lightRotation.z = 0f;
        if (Input.GetKeyDown("d") || h > 0)
        {
            lightRotation.y = -90f;
            if (playerRigidbody.rotation != Quaternion.Euler(0, 90f, 0))
                playerRigidbody.MoveRotation(Quaternion.Euler(0, 90f, 0));           
        }

        else if (Input.GetKeyDown("a") || h < 0)
        {
            lightRotation.y = 90f;
            if (playerRigidbody.rotation != Quaternion.Euler(0, -90f, 0))
                playerRigidbody.MoveRotation(Quaternion.Euler(0, -90f, 0));
        }
    }
}
