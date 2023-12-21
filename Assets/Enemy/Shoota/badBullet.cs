using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badBullet : MonoBehaviour
{
    public float bulletLifetime = 1f;
    public GameObject shoota;
    // Start is called before the first frame update. Baseret på kode fra bullet af Matthias fra gruppe 103.
    void Start()
    {
        //selfdestroyer efter bulletLifetime, aka. 1f.
        Destroy(gameObject, bulletLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //selfdestroyer når den collider med noget.
        Destroy(gameObject);
    }
}
