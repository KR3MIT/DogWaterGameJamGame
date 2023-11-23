using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public GameObject blockingDude;
    public BoxCollider2D hurtbox;
    public Animator animController;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("death!");
            animController.SetBool("death", true);
            Destroy(blockingDude, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
