using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarManager : MonoBehaviour
{
   
    public int starCount;
    public Text starText;

    void Update()
    {
        starText.text = starCount.ToString();
    }
}

