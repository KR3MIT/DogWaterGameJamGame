using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script has been developed with the help of ChatGPT

public class Weapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 50f;
    public float timeBetweenShots = 0.2f;
    public int burstShots = 3;
    public float burstCooldown = 3f;
    public float knockbackForce = 1f;

    private bool canShoot = true;
    private int shotsRemaining;

    public GameObject player;

    void Update()
    {
            // These if statements check which way the player wants to shoot and calls the ShootBurst method in the correct direction
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine(ShootBurst(Vector2.up));
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(ShootBurst(Vector2.right));
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine(ShootBurst(Vector2.down));
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(ShootBurst(Vector2.left));
            }
    }
    // Coroutine for shooting a burst of bullets
    IEnumerator ShootBurst(Vector2 direction)
    {
        // Check if the player is allowed to shoot
        if (canShoot)
        {
            // Set canShoot to false to prevent starting another burst before the current one is complete
            canShoot = false;

            // Loop through the specified number of shots in the burst
            for (int i = 0; i < burstShots; i++)
            {
                // Shoot a bullet in the specified direction
                ShootBullet(direction);

                // Pause the coroutine for a duration of timeBetweenShots before the next shot
                yield return new WaitForSeconds(timeBetweenShots);
            }

            // Pause the coroutine for a cooldown period after the burst
            yield return new WaitForSeconds(burstCooldown);

            // Set canShoot back to true, allowing the player to initiate another burst after the cooldown period
            canShoot = true;
        }
    }

    void ShootBullet(Vector2 shotDirection)
    {
        // Instantiate bullet and shoot in the determined direction
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(shotDirection * bulletSpeed, ForceMode2D.Impulse);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetPlayer(player);
        }

        // Apply knockback force to the player
        ApplyKnockback(shotDirection);
    }

    void ApplyKnockback(Vector2 knockbackDirection)
    {
        // Calculate the opposite direction for knockback
        Vector2 oppositeDirection = -knockbackDirection;

        // Apply knockback force to the player
        Rigidbody2D playerRb = GetComponent<Rigidbody2D>();
        playerRb.AddForce(oppositeDirection * knockbackForce, ForceMode2D.Impulse);
    }
}


   