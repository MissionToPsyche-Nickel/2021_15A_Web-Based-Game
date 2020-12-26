using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Power-up triggers questions. Player gets 1000 points if they hit
// it and an extra life if they anwser the question right.
public class PowerUP : MonoBehaviour
{
    [SerializeField] private GameObject question;

    void Start()
    { 
        question = GameObject.Find("Trivia Panel");
        question.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D objectCollider)
    {
        if (objectCollider.CompareTag("Psyche"))
        {
            Destroy(gameObject);
            // Actually adds 1000 points but the final number is multiplied by 5
            GameObject.Find("Score").GetComponent<ScoreUI>().score+=200;
            question.SetActive(true);
            //pauses most operations in-game except UI
            Time.timeScale = 0f;
        }
    }
}
