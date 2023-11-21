using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D myBody;
    public int speed = 5;
    public float jump;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        
    }
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        myBody.velocity = movement * speed;
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            myBody.AddForce(new Vector2(myBody.velocity.x, jump));
            Debug.LogFormat("hop");
        }
      
    }
}
