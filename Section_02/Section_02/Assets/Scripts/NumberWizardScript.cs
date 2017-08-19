using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizardScript : MonoBehaviour {

    int min = 1;
    int max = 1000;
    int guess = 500;
    int count = 0;

    void PromptGuess()
    {
        print("Is the number higher or lower than " + guess + "?");
    }

    void StartGame()
    {
        min = 1;
        max = 1000;
        guess = 500;
        count = 0;

        print("Welcome to Number Wizard!");
        print("Pick a number in your head, but don't tell me!");

        print("The highest number you can pick is " + max + ".");
        print("The lowest number you can pick is " + min + ".");

        print("Is the number higher or lower than " + guess + "?");
        print("Up Arrow for higher, Down Arrow for lower, Return for equal.");

        max++;
    }

    // Use this for initialization
    void Start() {
        StartGame();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            guess = (max + min) / 2;
            PromptGuess();
            count++;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            guess = (max + min) / 2;
            PromptGuess();
            count++;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            print("I've won in " + count + " guesses!");
            print("===============================================");
            StartGame();
        }
    }
}
