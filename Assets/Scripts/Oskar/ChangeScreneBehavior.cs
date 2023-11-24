using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreneBehavior : MonoBehaviour
{
    //if something collides with the collider of the holder of the script
    public void OnTriggerEnter2D(Collider2D other)
    {
        //check if the collider/object has the tag "Exit"
        if (other.gameObject.CompareTag("Exit"))
        {
            //if it does, load scene 2
            SceneManager.LoadScene("Level2");
            //and print load in console
            Debug.LogFormat("load");
        }
    }
    //this is set to onlick on the button so it Loads the scene of the string name 
    public void LoadScene(string sceneName)
    {
        //when button is pressed load scene with the name set in unity
        SceneManager.LoadScene(sceneName);
        //aand print load 2
        Debug.LogFormat("load2");
    }
}