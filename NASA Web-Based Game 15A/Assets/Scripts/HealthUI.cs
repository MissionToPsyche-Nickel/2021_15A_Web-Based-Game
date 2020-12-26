using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public int health = 3;
    
    public bool GameOverSoundplayed = false;
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
            if (GameOverSoundplayed == false)
            {
                SoundManager.instance.PlaySound("GameOverSound");
                GameOverSoundplayed = true;
            }
            GameObject.Find("GameController").GetComponent<GameStart>().gameOver = true;
            HealthText.text = "";
            gameOverText.text = "GAME OVER:" + "\n" + "FINAL SCORE: " + GameObject.Find("Score").GetComponent<ScoreUI>().finalScore;
        }
        else
        {
            HealthText.text = "Health: " + health;
            gameOverText.text = "";
        }
    }
}
