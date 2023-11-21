using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Shoot(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Shoot(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Shoot(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Shoot(Vector2.left);
        }
    }

    void Shoot(Vector2 direction)
    {
       GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

}
