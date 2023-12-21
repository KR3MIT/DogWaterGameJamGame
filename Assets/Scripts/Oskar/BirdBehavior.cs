using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehavior : MonoBehaviour
{
    private float speed;
    private float DirectionX;
    private Rigidbody2D rb;
    private bool facingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DirectionX = -1f;
        speed = 3f;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
    if (other.gameObject.CompareTag("Floor"))

        {
            DirectionX *= -1f;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(DirectionX * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
