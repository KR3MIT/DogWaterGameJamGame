using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreneBehavior : MonoBehaviour
{
  public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadScene(2);
            Debug.LogFormat("load");
        }
    }
}
