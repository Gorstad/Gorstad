using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   int score = 0;
   Text scoreText;
    void Start()
    {
       scoreText = GetComponent<Text>();
       scoreText.text = score.ToString();
    }
    public void ScoreHit(int ScorePerHit)
    {
        score = score + ScorePerHit;
        scoreText.text = score.ToString();
    }


}
