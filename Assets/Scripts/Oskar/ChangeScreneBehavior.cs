using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneBehavior : MonoBehaviour
{


    // Check for collisions and load Level2 if starCount is 15, otherwise do nothing
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            StarManager starManager = GameObject.Find("StarManager").GetComponent<StarManager>();
            int starCount = starManager.starCount;

            if (starCount == 15)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene("Level3");
            }
            else
            {
                SceneManager.LoadScene("Level2");
            }
        }



    }

    // Load scene by name from the click event
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.LogFormat("Load2");
    }
}
