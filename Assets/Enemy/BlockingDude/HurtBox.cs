using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public GameObject blockingDude;
    public BoxCollider2D hurtbox;
    public Animator animController;
    
    //tjekker om den collider med en collider.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hvis den collider med en collider med tagget "Bullet" s� d�r enemien.
        if (collision.gameObject.tag == "Bullet")
        {
            //spiller animationenen death og d�r efter animationen.
            Debug.Log("death!");
            animController.SetBool("death", true);
            Destroy(blockingDude, 1f);
        }
    }
}
