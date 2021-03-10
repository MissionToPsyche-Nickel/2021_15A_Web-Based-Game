using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("GameLevel");
    }
    
    public void MMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Tutorial()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void ScoreBoard()
    {
        SceneManager.LoadScene("Scoreboard");
    }
}
