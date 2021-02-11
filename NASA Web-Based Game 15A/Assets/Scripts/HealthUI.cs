using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public int health = 3;
    
    public bool GameOverSoundplayed = false;
    public TextMeshProUGUI gameOverText;

    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        gameOverScreen();
    }

    public void gameOverScreen()
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
            gameOverText.text = "GAME OVER:" + "\n" + "FINAL SCORE: " + GameObject.Find("Score").GetComponent<ScoreUI>().finalScore
                                + "\n\nPress M to return to main menu";

            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("M Pressed");
                SceneManager.LoadScene("MainMenu");
            }
        }
        else
        {
            HealthText.text = "Health: " + health;
            gameOverText.text = "";
        }
    }
}
