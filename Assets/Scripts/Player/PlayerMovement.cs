using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce = 8f;

    Vector3 movement;
    Animator anim;
    CharacterController playerController;
    int floorMask;
    float camRayLength = 100f;
    float verticalVelocity;
    float gravity = 15f;
    

    void Awake ()
    {
        floorMask = LayerMask.GetMask ("Floor");
        anim = GetComponent<Animator> ();
        playerController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {

        float h = Input.GetAxisRaw ("Horizontal");
        Animating(h);

        if (playerController.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 moveVector = Vector3.zero;
        moveVector.x = h * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = 0f;
        playerController.Move(moveVector * Time.deltaTime);

        
    }

    void Animating(float h)
    {
        bool walking = h != 0f && true;
        anim.SetBool ("IsWalking", walking);
    }

}
