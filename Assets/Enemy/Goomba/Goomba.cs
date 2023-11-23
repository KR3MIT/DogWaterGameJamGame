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
    private Transform currentTransform;

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
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentTransform = GetComponent<Transform>();
        anim.SetBool("isWalking", true);
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(walkDirection * walkSpeed, rb.velocity.y);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            walkDirection = 0;
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(raycastPivot.transform.position, Vector2.down, raycastDistance);
        Debug.DrawRay(raycastPivot.transform.position, Vector2.down * hitGround.distance, Color.red);

        if (hitGround == GameObject.FindGameObjectWithTag("Floor"))
        {
            Debug.Log("ground");
        }
        else
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
