using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehavior : MonoBehaviour
{
    public GameObject raycastPivot;
    private float raycastDistance = 3;
    private int flySpeed = 2;
    private int walkDirection = 1;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentTransform = GetComponent<Transform>();
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
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitWall = Physics2D.Raycast(raycastPivot.transform.position, Vector2.left, raycastDistance);
        Debug.DrawRay(raycastPivot.transform.position, Vector2.left * hitWall.distance, Color.red);

        if (hitWall == GameObject.FindGameObjectWithTag("Floor"))
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
            Debug.Log("Wall");
          
        }
        else
        {
            Debug.Log("no Wall");

        }
    }
}
