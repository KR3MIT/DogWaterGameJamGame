using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnPlayClick()
    {
        SceneManager.LoadScene("Level1");
    }
    public void OnExitClick() { 
        Application.Quit();
    }

}
