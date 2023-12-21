using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Goomba : MonoBehaviour
{
    public GameObject raycastPivot;
    [SerializeField] private int walkSpeed = 1;
    [SerializeField] private float raycastDistance = 3;
    private int walkDirection = 1;
    private Rigidbody2D rb;
    private Animator anim;
    //private Transform currentTransform;

    //discarted health mechanic.
    //public int health = 1;

    //public void TakeDamage(int damage)
    //{
    //    health -= damage;

    //    // Check if the enemy's health is less than or equal to zero
    //    if (health <= 0)
    //    {
    //        // Call a method to handle the enemy's destruction
    //        Die();
    //    }
    //}

    //void Die()
    //{
    //    // Destroy the enemy GameObject
    //    Destroy(gameObject);
    //}


    // Start is called before the first frame update
    void Start()
    {
        //get reference to componemts
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //currentTransform = GetComponent<Transform>();
        anim.SetBool("isWalking", true);
        
    }

    void FixedUpdate()
    {
        //moves the enemy using the rigidbody velocity. From a tutorial https://www.youtube.com/watch?v=RuvfOl8HhhM&t=274s
        rb.velocity = new Vector2(walkDirection * walkSpeed, rb.velocity.y);
    }
    
    //this is where it checks for collision with other colliders.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //here it checks for collision with a specifik tag.
        if (collision.gameObject.tag == "Bullet")
        {
            //if it collides with a collider with tag "Bullet" it stops walking and selfdestroys.
            walkDirection = 0;
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // it makes a raycast a new raycastHit2D called "hitGround". A raycast needs min. 3 values to work, origin, direction and distance. 
        //Vector2.down is a build in unity funktion. could also be written (0,-1) as it is a vector2.
        RaycastHit2D hitGround = Physics2D.Raycast(raycastPivot.transform.position, Vector2.down, raycastDistance);

        //debug to visualize the raycast in playmode. 
        Debug.DrawRay(raycastPivot.transform.position, Vector2.down * hitGround.distance, Color.red);

        //checks if hitGround hits a gameobject with the tag floor.
        if (hitGround == GameObject.FindGameObjectWithTag("Floor"))
        {
            //writes ground in the console.
            //Debug.Log("ground");
        }
        else //if it does not.
        {
            //se if it is currently walking right.
            if (walkDirection == 1)
            {
                //if it is, walk left.
                walkDirection = -1;
            }
            else
            {
                //if not walk right.
                walkDirection = 1;
            }

            //When hitGround does not hit any ground, it turns the entire object 180 degrees, and walks the other direction. 
            transform.Rotate(0f, 180f, 0f);
            Debug.Log("no ground");
            
        }
    }
}
