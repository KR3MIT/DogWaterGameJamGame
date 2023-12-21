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
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isFlying", true);
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(walkDirection * flySpeed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            walkDirection = 0;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Floor")
        {
            if (walkDirection == 1)
            {
                walkDirection = -1;
            }
            else
            {
                walkDirection = 1;
            }
            transform.Rotate(0f, 180f, 0f);
            Debug.Log("no ground");
        }

    }
}

