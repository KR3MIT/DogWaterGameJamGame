using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


//This script has been developed with the help of ChatGPT and Pandemonium (https://www.youtube.com/watch?v=_UBpkdKlJzE&t=24s)
public class JumpBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private int jumpPower;
    public bool isJumping;
    private BoxCollider2D boxCollider;
    private float fallingOffSet = -0.1f;
    [SerializeField] private LayerMask groundLayer;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the player is allowed to jump, "Jump" is the new inputs systems spacebar.
        if (Input.GetButtonDown("Jump") && isGrounded())
        {

            //makes a new vector that keeps the rb x position but pushes the y with jumpPower
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            //writes "hop" in console
            Debug.LogFormat("hop");
            animator.SetBool("isJumping", true);
        }

        else animator.SetBool("isJumping", false);

        if (rb.velocity.y < fallingOffSet)
        {
            animator.SetBool("isFalling", true);

        }
        else animator.SetBool("isFalling", false);

    }

    // awake is called as soon as an active gameobject with its script is loaded
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    //isGrounded is one of the parameter that tells the script wether or not the player is jumping
    private bool isGrounded()
    {
        //We are using a BoxCast to determine wether or not the player is colliding with groundLayer or not.
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        //when the raycast hit nothing, isgrounded is set to null and therefore is the player jumping
        return raycastHit.collider != null;
    }
}