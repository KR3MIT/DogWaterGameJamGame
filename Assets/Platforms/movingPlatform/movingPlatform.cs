using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public bool isMoving = true;
    [SerializeField] private int movingSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pointA != null)
        {
            MoveToPoint();
        }
    }
    void MoveToPoint()
    {
        float _move = movingSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, pointA.position, _move);
    }
}
