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
    [SerializeField] private GameObject replayButton;
    [SerializeField] private GameObject menuButton;

    void Start()
    {
        health = 3;
        scoreAdded = false;
        replayButton.SetActive(false);
        menuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameOverScreen();
        }
        else
        {
            HealthText.text = "Health: " + health;
            gameOverText.text = "";
        }
    }

    public void GameOverScreen()
    {
        if (gameOverSoundplayed == false)
        {     
                SoundManager.instance.PlaySound("GameOverSound");
                gameOverSoundplayed = true;
        }
        
        GameObject.Find("GameController").GetComponent<GameStart>().gameOver = true;
        HealthText.text = "";
        gameOverText.text = "GAME OVER:" + "\n" + "FINAL SCORE: " +
                            GameObject.Find("Score").GetComponent<ScoreUI>().finalScore;
        
        replayButton.SetActive(true);
        menuButton.SetActive(true);
        
        // add to score board
        if(!scoreAdded)
        {
            GameObject.Find("Scoreboard").GetComponent<Scoreboard>().AddEntry(GameObject.Find("Score").GetComponent<ScoreUI>().finalScore);
                scoreAdded = true;
        }
        
    }
    
    // Used for Replay? button on game over screen 
    public void ReplayLevel()
    {
        replayButton.SetActive(false);
        SceneManager.LoadScene("GameLevel");
    }
    
    // Used for Replay? button on game over screen 
    public void MainMenu()
    {
        menuButton.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
