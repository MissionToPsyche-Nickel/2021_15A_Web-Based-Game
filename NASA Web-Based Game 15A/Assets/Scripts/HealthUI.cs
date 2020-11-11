using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public int health = 3;
    public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            GameObject.Find("GameController").GetComponent<GameStart>().gameOver = true;
            HealthText.text = "";
            gameOverText.text = "GAME OVER:" + "\n" + "FINAL SCORE: " + GameObject.Find("Score").GetComponent<ScoreUI>().score;
            
        }
        else
        {
            HealthText.text = "Health: " + health;
            gameOverText.text = "";
        }
    }
}
