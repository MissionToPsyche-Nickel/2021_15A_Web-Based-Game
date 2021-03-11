using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool inPauseMenu = false;
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private GameObject triviaPanel;
    public int health;

    void Start()
    {
        triviaPanel = GameObject.Find("Trivia Panel");
        pausePanel = GameObject.Find("Pause Panel");
        pausePanel.SetActive(false);
        inPauseMenu = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            health = GameObject.Find("Health").GetComponent<HealthUI>().health;
            if (inPauseMenu == false && (health > 0))
                PauseGame();
            else
                ResumeGame();
        }
    }

    public void ResumeGame()
    {
		//triviaPanel = GameObject.Find("Trivia Panel");
        if(ReferenceEquals(triviaPanel, null))
        {
            Time.timeScale = 1f;
        }
        pausePanel.SetActive(false);
        inPauseMenu = false;
    }

    private void PauseGame()
    {
        pausePanel.SetActive(true);
        inPauseMenu = true;
		Time.timeScale = 0f;
    }
    
    public void ExitGame()
    {
        pausePanel.SetActive(false);
        inPauseMenu = false;
        GameObject.Find("Health").GetComponent<HealthUI>().health = 0;
		GameObject.Find("Health").GetComponent<HealthUI>().GameOverScreen();
    }
}
