using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehavior : MonoBehaviour
{
    private int flySpeed = 2;
    private int walkDirection = -1;
    private Rigidbody2D rb;
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        // we define rb and anim to the gameobjects rigidbody and animator components
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // as the bird only has one animation, we set the trigger for the animation to be true from start as this will never change.
        anim.SetBool("isFlying", true);
    }
    void FixedUpdate()
    {
        //we set the velocity of the gameobject by making a new vector with the values of walkdirection and flyspeed multiplied and 0 as there is no value for rb.velocity.y
        //this will result in vertical movement exclusively
        rb.velocity = new Vector2(walkDirection * flySpeed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the gameobject with this script attatched to it, collides with an object with the tag "Bullet" this gameobject stops and is destroyed
        if (collision.gameObject.tag == "Bullet")
        {
            walkDirection = 0;
            Destroy(gameObject);
        }
        // if the gameobject collides with an object with the tag "Floor" the gameobject will change direction
        // and change the value of walkDirection to the opposite(from + to -, or from - to +) and therefore change direction aswell
        if (collision.gameObject.tag == "Floor")
        {
            // if the value of walkDirection is 1 on collison, set it to -1
            if (walkDirection == 1)
            {
                walkDirection = -1;
            }
            //else, which is when its value is -1, set it to 1
            else
            {
                walkDirection = 1;
            }
            //if the gameobject collides with tag "Floor" rotate the gameobject 180 on its y-axis
            transform.Rotate(0f, 180f, 0f);
            //
            Debug.Log("Wall Hit");
        }

    }
}

