using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMode : MonoBehaviour
{
    public PlayerBehaviour playerBehaviour; // Reference to the PlayerBehaviour script
    private float normalSpeed; // Store the normal speed before forcing to 0
  public  JumpBehavior jumpBehavior;
    void Start()
    {

            normalSpeed = playerBehaviour.speed;
        Debug.Log("normalSpeed");
    }

    void Update()
    {
        // Check if the playerBehaviour reference is not null before using it
        if (playerBehaviour != null && jumpBehavior != null)
        {
            // Check if the player is on the ground
            if (jumpBehavior.isGrounded())
            {
                // Force speed to 0 when on the ground
                playerBehaviour.speed = 0f;
            }
            else
            {
                // Set speed back to normal when not on the ground
                playerBehaviour.speed = normalSpeed;
            }
        }
        else
        {
            Debug.LogWarning("playerBehaviour or jumpBehavior is null. Make sure they are properly initialized.");
        }
    }
}

// inspired by chatGPT and Bard AI