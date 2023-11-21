using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        // Check for arrow key input and start burst immediately
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
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
    }

    IEnumerator ShootBurst(Vector2 direction)
    {
        if (canShoot)
        {
            canShoot = false;

            for (int i = 0; i < burstShots; i++)
            {
                ShootBullet(direction);
                yield return new WaitForSeconds(timeBetweenShots);
            }

            yield return new WaitForSeconds(burstCooldown);

            canShoot = true;
        }
    }

    void ShootBullet(Vector2 shotDirection)
    {
        // Instantiate bullet and shoot in the determined direction
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(shotDirection * bulletSpeed, ForceMode2D.Impulse);

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


    /* void Update()
     {

         //Depending on which arrow key the player presses, the Shoot() parameter is changed to that direction
         if (Input.GetKeyDown(KeyCode.UpArrow))
         {
             Shoot(Vector2.up);
         }
         else if (Input.GetKeyDown(KeyCode.RightArrow))
         {
             Shoot(Vector2.right);
         }
         else if (Input.GetKeyDown(KeyCode.DownArrow))
         {
             Shoot(Vector2.down);
         }
         else if (Input.GetKeyDown(KeyCode.LeftArrow))
         {
             Shoot(Vector2.left);
         }
     }

     void Shoot(Vector2 direction)
     {
         //The bullet is instantiated into the game as the bullet prefab at the firePoint position. Quaternion.identity ensures that the bullet has no rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);


         Bullet bulletScript = bullet.GetComponent<Bullet>();

         Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
         if (bulletRb != null)
         {
             bulletRb.AddForce(direction * bulletScript.bulletSpeed, ForceMode2D.Impulse);
             Debug.Log("Direction:" + direction);
         }
     }*/


