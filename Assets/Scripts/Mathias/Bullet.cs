using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script has been developed with the help of ChatGPT

public class Bullet : MonoBehaviour
{

    public float bulletLifetime = 0.5f;

    void Start()
    {
        // Destroy the bullet GameObject after a specified lifetime
        Destroy(gameObject,bulletLifetime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Destroy the bullet when it collides with an object tagged as "Enemy"
            Destroy(gameObject);
        }
    }
}
