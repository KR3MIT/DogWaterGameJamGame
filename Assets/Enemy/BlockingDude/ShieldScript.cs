using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public BoxCollider2D shield;
    public Animator animController;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("parry!");
            animController.SetBool("parry",true);

            Invoke("stopParry", 1f);
        }
    }

    void stopParry()
    {
        animController.SetBool("parry", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
