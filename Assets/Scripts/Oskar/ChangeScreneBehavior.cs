using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeSceneBehavior : MonoBehaviour
{
    public float hardSpeed;
    public int hardJumpPower;



    // Check for collisions and load Level2 if starCount is 15, otherwise do nothing
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            StarManager starManager = GameObject.Find("StarManager").GetComponent<StarManager>();
            int starCount = starManager.starCount;

            if (starCount == 1)
            {
                difficultyIncrease();
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
        Debug.Log(sceneName);
    }

    public void difficultyIncrease()
    {
        PlayerBehaviour playerBehaviour = GameObject.Find("PlayerBehavior").GetComponent<PlayerBehaviour>();
        JumpBehavior jumpBehavioir = GameObject.Find("JumpBehavior").GetComponent<JumpBehavior>();
        playerBehaviour.speed = hardSpeed;
        jumpBehavioir.jumpPower = hardJumpPower;
    }


}
