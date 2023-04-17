using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnDetectPlayer : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotSpeed = 15.0f;
    public float jumpSpeed = 15.0f;
    public float gravity = -10.0f;
    public float terminalVelocity = -20.0f;
    public float minFall = -2.0f;
    public bool isjumping = false;
    private float vertSpeed;
    public Animator player_animator;
    public Animator animator;
    public CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // start with zero and add movement components progressively
        Vector3 movement = Vector3.zero;
        // raycast down to address steep slopes and dropoff edge
        bool hitGround = false;
        RaycastHit hit;
        if (vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float check = (charController.height + charController.radius) / 1.9f;
            hitGround = hit.distance <= check;  // to be sure check slightly beyond bottom of capsule
        }

        // y movement: possibly jump impulse up, always accel down
        // could _charController.isGrounded instead, but then cannot workaround dropoff edge
        if (hitGround)
        {
            if (isjumping)
            {
                vertSpeed = jumpSpeed;
            }
            else
            {
                vertSpeed = minFall;
                animator.SetBool("Jumping", false);
            }
        }
        else
        {
            vertSpeed += gravity * 5 * Time.deltaTime;
            if (vertSpeed < terminalVelocity)
            {
                vertSpeed = terminalVelocity;
            }

           
        }
        if (player_animator != null)
        {
            isjumping = player_animator.GetBool("Jumping");

        }
        movement.y = vertSpeed;
        movement *= Time.deltaTime;
        charController.Move(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
          if(other.gameObject.CompareTag("Player"))
        {
            player_animator = other.gameObject.GetComponent<Animator>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player_animator = null;
            isjumping = false;
        }
    }
}

