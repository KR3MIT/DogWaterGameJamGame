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

        // Check if the player is on the ground
        if (isGrounded)
        {
            // Apply sliding effect on ice
            if (isOnIce)
            {
                Vector2 velocity = rb.velocity;
                velocity.x *= iceFriction;
                rb.velocity = velocity;
            }
        }

        // Check if the player has stopped moving
        if (move == 0.0f && previousMove != 0.0f)
        {
            shouldDecelerate = true;
        }
        previousMove = move;

        // Apply custom deceleration when needed
        if (shouldDecelerate)
        {
            float horizontalVelocity = rb.velocity.x;
            horizontalVelocity *= (1 - decelerationRate * Time.deltaTime);

            // Ensures that the character eventually comes to a stop
            if (Mathf.Abs(horizontalVelocity) < 0.01f)
            {
                shouldDecelerate = false;
            }

            rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
        }

        // Activate the animator
        if (move > offSet || move < -offSet)
        {
            Animator.SetBool("isWalking", true);

            float rotationAngle = move > 0 ? 0f : (move < 0 ? 180f : 0f);
            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
        else
        {
            Animator.SetBool("isWalking", false);
        }
    }

    // Method when something collides with some other thing in 2D
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            starManager.starCount++;
            AudioSource audio = GetComponent<AudioSource>();
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
