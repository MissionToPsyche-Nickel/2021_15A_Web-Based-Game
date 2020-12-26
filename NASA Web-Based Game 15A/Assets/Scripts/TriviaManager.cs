using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This script stores all the questions and loads them onto the TriviaPanel.
//  Still need to add a way to clear buttons and pick a new question when
//  new powerups are triggered.
public class TriviaManager: MonoBehaviour
{
    public List<Trivia> triviaBank;
    public GameObject[] choiceButtons;
    public int currentQuestion;
    public TextMeshProUGUI questionText;

    void Start()
    {
        getRandomQuestion();
    }

    // Gets random question from trivia bank
    void getRandomQuestion()
    {
        currentQuestion = Random.Range(0, triviaBank.Count);
        questionText.text = triviaBank[currentQuestion].question;
        setChoices();
    }

   	// adds anwsers to buttons based on question and picks correct anwser.
   	// Use the inspector to set up questions and correct anwsers in TriviaManager
   	// GameObject
    void setChoices()
    {
        for (int button = 0; button < choiceButtons.Length; button++)
        {
            choiceButtons[button].GetComponent<TriviaAnwser>().isCorrect = false;
            string choiceText = triviaBank[currentQuestion].choices[button];
            choiceButtons[button].GetComponentInChildren<TextMeshProUGUI>().text = choiceText;
            
            // Note that the correct options go from 1 to 4 due to how buttons work.
            // Keep it in mind when picking which button is the correct anwser.
			if(triviaBank[currentQuestion].correctChoice == button+1)
			{
				choiceButtons[button].GetComponent<TriviaAnwser>().isCorrect = true;
			}

        }
    }

    // Returns the button with the correct anwser
    public GameObject getCorrectChoice()
    {
		GameObject choice = choiceButtons[0];

        for (int button = 0; button < choiceButtons.Length; button++)
        {
			if(triviaBank[currentQuestion].correctChoice == button+1)
			{
				choice =  choiceButtons[button];
			}
        }
		return choice;
    }
}
