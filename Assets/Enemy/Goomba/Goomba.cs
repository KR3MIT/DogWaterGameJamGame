using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Goomba : MonoBehaviour
{
    public GameObject raycastPivot;
    public bool alive = true;
    [SerializeField] private int walkSpeed = 1;
    [SerializeField] private float raycastDistanec = 3;
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
        anim.SetBool("isWalking", true);
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(walkDirection * walkSpeed, rb.velocity.y);
        
         
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(raycastPivot.transform.position, Vector2.down, raycastDistanec);
        Debug.DrawRay(raycastPivot.transform.position, Vector2.down * hitGround.distance, Color.red);
        
        if (hitGround.collider !=null)
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
