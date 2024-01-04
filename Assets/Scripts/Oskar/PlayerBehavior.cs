using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    private float move;
    private float offSet = 0.1f;

    public Rigidbody2D rb;
    public StarManager starManager;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Called every frame
    void Update()
    {
        // Gets the new input systems horizontal controls
        move = Input.GetAxis("Horizontal");

        // Makes a new vector that moves the player on the y-axis with the public float speed
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if (move > offSet || move < -offSet)
        {
            animator.SetBool("isWalking", true);
            float rotationAngle = move > 0 ? 0f : (move < 0 ? 180f : 0f);
            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    // Method when something collides with some other thing in 2D
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the game object that collides has the tag "Collectable"
        if (other.gameObject.CompareTag("Collectable"))
        {
            // Destroy the game object
            Destroy(other.gameObject);
            // Increment starCount in StarManager
            starManager.starCount++;
            // Get sound from the AudioSource component and play it
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
