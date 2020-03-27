using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public static int gscore = 0;
    public Text scoreText;
    //public GameObject youWin;

    private void Update()
    {
        scoreText.text = "SCORE: " + gscore;
    }
}
