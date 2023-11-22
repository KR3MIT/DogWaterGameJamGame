using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    private float Move;

    public Rigidbody2D rb;
    public StarManager starManager;


    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            starManager.starCount++;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play(); 
        }
    }

}
