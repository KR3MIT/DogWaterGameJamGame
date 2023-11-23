using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingDude : MonoBehaviour
{
    public GameObject raycastPivot;
    [SerializeField] private int walkSpeed = 1;
    [SerializeField] private float raycastDistance = 3;
    private int walkDirection = 1;
    private Rigidbody2D rb;
    private Animator animController;
    private Transform currentTransform;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animController = GetComponent<Animator>();
        currentTransform = GetComponent<Transform>();
        animController.SetBool("isWalking", true);
        animController.SetBool("parry", false);
        animController.SetBool("death", false);
    }

    void FixedUpdate()
    {
        //walking, vector2(x,y), giver rigidbody velocity en ny velocity med vector2.
        rb.velocity = new Vector2(walkDirection * walkSpeed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        //skyder en raycast hver Update og tjekker om den collider med noget. raycast skal bruge en origin, direction of distance.
        RaycastHit2D hitGround = Physics2D.Raycast(raycastPivot.transform.position, Vector2.down, raycastDistance);
        Debug.DrawRay(raycastPivot.transform.position, Vector2.down * hitGround.distance, Color.red);

        if (hitGround == GameObject.FindGameObjectWithTag("Floor"))
        {
            Debug.Log("ground");
        }
        else
        {
            //hvis den ikke collider med noget, så flip objectet og gå den modsatte vej.
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
