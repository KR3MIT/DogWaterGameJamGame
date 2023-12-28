using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public float move;
    private float offSet = 0.1f;

    public Rigidbody2D rb;
    public StarManager starManager;
    private Animator Animator;
    private JumpBehavior jumpBehavior;
    public float smoothTime;

    public float iceFriction = 0.05f;
    public float normalFriction = 0.5f;

    public bool isOnIce = true;

    public float previousMove;

    public float decelerationTime = 1.0f; // Time in seconds to come to a complete stop
    private float decelerationRate;
    private bool shouldDecelerate = false;



    private void Awake()
    {
        Animator = GetComponent<Animator>();
        jumpBehavior = GetComponent<JumpBehavior>();
        decelerationRate = 1 / decelerationTime;

    }


    void Update()
    {
        move = Input.GetAxis("Horizontal");

        bool isGrounded = jumpBehavior.isGrounded();

        // Apply movement
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        // Check if the player is on the ground and on ice
        if (isGrounded && isOnIce)
        {
            bool buttonDown = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

           // if (buttonDown) { shouldDecelerate = false; }
            // Check if the player has stopped moving
            if (buttonDown == false && move == 1) { shouldDecelerate = true; }
            

        }
        else
        {
            shouldDecelerate = false;
        }

        // Apply custom deceleration when needed
        if (shouldDecelerate)
        {
            float horizontalVelocity = rb.velocity.x;
            horizontalVelocity *= (1 - decelerationRate * Time.deltaTime);

            Debug.Log(horizontalVelocity+" "+rb.velocity.x+ ""+ decelerationRate);


            // Ensures that the character eventually comes to a stop
            if (Mathf.Abs(horizontalVelocity) < 0.01f)
            {
                horizontalVelocity = 0;
                shouldDecelerate = false;
            }

            rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
        }
       

       // actiavte the animator
        if (move > offSet || move < -offSet)
        {

            //previousMove = move;


            // Sets the 'isWalking' animation property to true
            Animator.SetBool("isWalking", true);

            // Rotates the player's transform based on the movement direction
            float rotationAngle = move > 0 ? 0f : (move < 0 ? 180f : 0f);
            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
        else
        {
            // Sets the 'isWalking' animation property to false
            Animator.SetBool("isWalking", false);
        }
    }

    // method when something collides with some other thing in 2D
    void OnTriggerEnter2D(Collider2D other)
    {
        // if the gameobject that collides has the tag collectable
        if (other.gameObject.CompareTag("Collectable"))
        {
            //destroy the gameobjecet
            Destroy(other.gameObject);
            //plus one in starmangager starCount
            starManager.starCount++;
            //get sound in the audio source component
            AudioSource audio = GetComponent<AudioSource>();
            //and play that sound
            audio.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("You Died :(");
            // Reset the game by reloading the current scene when the player hits an enemy and dies
            ReloadScene();
        }
    }


    void ReloadScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
