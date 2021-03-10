using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public int health = 3;
    private bool scoreAdded;
    
    public bool gameOverSoundplayed = false;
    public TextMeshProUGUI gameOverText;

    void Start()
    {
        health = 3;
        scoreAdded = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameOverScreen();
    }

    public void gameOverScreen()
    {
        if(health <= 0)
        {
            if (gameOverSoundplayed == false)
            {
                SoundManager.instance.PlaySound("GameOverSound");
                gameOverSoundplayed = true;
            }
            GameObject.Find("GameController").GetComponent<GameStart>().gameOver = true;
            HealthText.text = "";
            gameOverText.text = "GAME OVER:" + "\n" + "FINAL SCORE: " + GameObject.Find("Score").GetComponent<ScoreUI>().finalScore
                                + "\n\nPress M to return to main menu";

            // add to score board
            if(!scoreAdded)
            {
                GameObject.Find("Scoreboard").GetComponent<Scoreboard>().AddEntry(GameObject.Find("Score").GetComponent<ScoreUI>().finalScore);
                scoreAdded = true;
            }
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
