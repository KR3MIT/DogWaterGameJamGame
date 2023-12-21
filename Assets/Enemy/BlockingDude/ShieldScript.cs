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
    //tjekker efter collitions med colliders.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hvis den collider med en collider med tag "Bullet".
        if (collision.gameObject.tag == "Bullet")
        {
            //så starter den parry.
            Debug.Log("parry!");
            animController.SetBool("parry",true);

            Invoke("stopParry", 1f);
        }
    }
    //når parry bliver brugt, så spiller den parry animationen.
    void stopParry()
    {
        animController.SetBool("parry", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
