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
        // starText is a string that displays the current amount in StarCount
        starText.text = starCount.ToString();
    }
}

