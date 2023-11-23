using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badBullet : MonoBehaviour
{
    public float bulletLifetime = 1f;
    public GameObject shoota;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
