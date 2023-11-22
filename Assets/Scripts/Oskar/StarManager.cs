using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarManager : MonoBehaviour
{
   
    public int starCount;
    public Text coinText;

    void Update()
    {
        coinText.text = starCount.ToString();
    }
}

