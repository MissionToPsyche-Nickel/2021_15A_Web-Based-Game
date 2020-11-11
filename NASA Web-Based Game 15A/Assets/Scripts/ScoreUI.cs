using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void Update()
    {   

        if(GameObject.Find("GameController").GetComponent<GameStart>().gameOver == true)
        {
            scoreText.text = "";
        }
        else
        {
            score = (int)Time.time * 5;
            scoreText.text = "SCORE: " + score;
        }
    }
}
