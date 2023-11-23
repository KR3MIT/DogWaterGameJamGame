using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script has been developed with the help of ChatGPT

public class CameraScript : MonoBehaviour
{
    // Reference to the player's Transform component
    public Transform playerTransform;

    // Smoothness factor for camera movement
    public float smoothSpeed = 0.125f;

    // LateUpdate is called after all Update methods have been called
    void LateUpdate()
    {
        // Check if the playerTransform is assigned
        if (playerTransform != null)
        {
            // Calculate the desired position for the camera using Vector2
            Vector2 desiredPosition = new Vector2(transform.position.x, playerTransform.position.y);

            // Smoothly interpolate between the current and desired positions using Vector2. Lerp is used for the smooth transitions
            Vector2 smoothedPosition = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), desiredPosition, smoothSpeed);

            // Set the camera's position to the smoothed position
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}