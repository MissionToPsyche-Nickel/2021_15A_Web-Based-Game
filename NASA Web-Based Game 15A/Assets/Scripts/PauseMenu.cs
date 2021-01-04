using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool inPauseMenu = false;
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private GameObject triviaPanel;

    void Start()
    {
	  
      triviaPanel = GameObject.Find("Trivia Panel");
	  pausePanel = GameObject.Find("Pause Panel");
      pausePanel.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P Pressed");
            PauseGame();
        }
    }

    public void ResumeGame()
    {
		triviaPanel = GameObject.Find("Trivia Panel");
        if(triviaPanel == null)
        {
            Time.timeScale = 1f;
        }
        pausePanel.SetActive(false);
        inPauseMenu = false;
    }

    public void PauseGame()
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
		GameObject.Find("Health").GetComponent<HealthUI>().gameOverScreen();
    }
}
