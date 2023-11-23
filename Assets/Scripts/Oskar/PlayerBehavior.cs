using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    private float Move;

    public Rigidbody2D rb;
    public StarManager starManager;
    
    
    //called every frame
    void Update()
    {
        //gets the new inputs systems horizontal controls
        Move = Input.GetAxis("Horizontal");
       
        //makes new vector that moves the player on y axis with the public float speed
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
    }
    // method when something collides with some other thing in 2D
    void OnTriggerEnter2D(Collider2D other)
    {
        // if the gameobject that collides has the tag collectable
        if(other.gameObject.CompareTag("Collectable"))
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
