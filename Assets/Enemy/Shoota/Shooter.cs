using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooter : MonoBehaviour
{
    public GameObject player;
    public GameObject badBullet;
    public Transform firePoint;
    public Animator animController;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float badBulletSpeed = 0.8f;
    [SerializeField] private float raycastDistance = 3;
    [SerializeField] private LayerMask ignoreLayer;
    private float playerAngle;
    private Vector2 rayDirection;
    private float lastShotTime;


    // Start is called before the first frame update
    void Start()
    {
        //for en ref til prefab objected bullet.
        Rigidbody2D bulletRb = badBullet.GetComponent<Rigidbody2D>();

        //sætter animationen shooting til false.
        animController.SetBool("isShooting", false);
    }

    // Update is called once per frame
    void Update()
    {
        //hvis player ikke er lige med ingen. //hjælp fra chatGPT
        if (player != null)
        {
            //så udregn afstanden af spilleren fra enemien.
            Vector3 directionToPlayer = player.transform.position - transform.position;

            //udregner vinklen fra afstanden.
            playerAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

            //når der er en spiller så "PerformShootAction".
            transform.rotation = Quaternion.AngleAxis(playerAngle, Vector3.forward);

            PerformRaycast();
        }
    }

    //tjekker om spilleren er indfor en raycast med distance raycastDistance.
    void PerformRaycast()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(this.transform.position, rayDirection, raycastDistance, ignoreLayer);
        rayDirection = new Vector2(Mathf.Cos(playerAngle * Mathf.Deg2Rad), Mathf.Sin(playerAngle * Mathf.Deg2Rad));
        Debug.DrawRay(this.transform.position, rayDirection * raycastDistance, Color.red);
        //Debug.Log(hitGround.collider.name);

        //if collider hit != nothing
        if(hitGround.collider != null)
        {
            //collition with object with tag player. then shoot.
            if (hitGround.collider.tag == "Player")
            {
                PerformShootAction();
            }
        }
    }
    
    //tjekker om spilleren er indfor en raycast med distance raycastDistance.
    void PerformShootAction()
    {
        // Check if the player is within shooting distance, there is a clear line of sight, and enough time has passed since the last shot
        if (Vector3.Distance(transform.position, player.transform.position) <= raycastDistance && CanShoot())
        {
            //play animation and "Shoot".
            animController.SetBool("isShooting", true);
            Shoot();
            //Debug.Log("Shooting!");
        }
        else
        {
            animController.SetBool("isShooting", false);
        }
    }
    
    void Shoot() //hjælp fra chatGPT
    {
        //spawner en instance af prefab objected bullet.
        GameObject projectile = Instantiate(badBullet, firePoint.position, Quaternion.identity);
        // Rotate the projectile towards the player
        projectile.transform.rotation = Quaternion.AngleAxis(playerAngle, Vector3.forward);
        // Apply force to the projectile to make it move
        projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.right * badBulletSpeed;
        lastShotTime = Time.time;
        Debug.Log("Shooting!");
    }

    bool CanShoot()
    {
        // Check if enough time has passed since the last shot based on the fire rate
        return Time.time - lastShotTime >= fireRate;

    }
}