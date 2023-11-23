using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooter : MonoBehaviour
{
    public Transform player;
    public GameObject badBullet;
    public Transform firePoint;
    public Animator animController;
    [SerializeField] private float fireRate= 0.5f;
    [SerializeField] private float badBulletSpeed = 0.8f;
    [SerializeField] private float raycastDistance = 3;
    private float playerAngle;
    private Vector2 rayDirection;
    private float lastShotTime;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D bulletRb = badBullet.GetComponent<Rigidbody2D>();
        animController.SetBool("isShooting", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;

            playerAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(playerAngle, Vector3.forward);
        }

        rayDirection = new Vector2 (Mathf.Cos(playerAngle * Mathf.Deg2Rad), Mathf.Sin(playerAngle * Mathf.Deg2Rad));

        RaycastHit2D shootRay = Physics2D.Raycast(this.transform.position, rayDirection, raycastDistance);
        Debug.DrawRay(this.transform.position, rayDirection * raycastDistance, Color.red);

        if (shootRay.collider == null)
        {
            // Nothing in the way and within shooting distance, so perform the shoot action
            if (Vector3.Distance(transform.position, player.position) <= raycastDistance && CanShoot())
            {
                Debug.Log("Shooting!");
                animController.SetBool("isShooting", true);
                Shoot();
            }
        }
        else
        {
            animController.SetBool("isShooting", false);
        }
        void Shoot()
        {
            GameObject projectile = Instantiate(badBullet, firePoint.position, Quaternion.identity);
            // Rotate the projectile towards the player
            projectile.transform.rotation = Quaternion.AngleAxis(playerAngle, Vector3.forward);
            // Apply force to the projectile to make it move
            projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.right * badBulletSpeed;
            lastShotTime = Time.time;
        }
        bool CanShoot()
        {
            // Check if enough time has passed since the last shot based on the fire rate
            return Time.time - lastShotTime >= 1f / fireRate;
            
        }
    }
}
