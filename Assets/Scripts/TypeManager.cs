using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeManager : MonoBehaviour
{
    public Text currentWordText;

    public static string wordToType = "";

    Enemy myCurrentTarget = null;
    string typedWord = "";
    int currentWordIndex = 0;
    List<int> completedWords = new List<int>();

    private void Start()
    {
        WordDatabase.LoadWords();   // TODO do this in word database initialization

        RandomizeNewWord();
    }

    void RandomizeNewWord()
    {
        wordToType = WordDatabase.FetchRandomWord();
        currentWordText.text = wordToType;
        typedWord = string.Empty;
        currentWordIndex = 0;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            string pressedButton = Input.inputString;

            if (myCurrentTarget == null)
            {
                myCurrentTarget = EnemySpawner.FetchEnemyMatchingLetter(pressedButton);
            }

            if (wordToType[currentWordIndex].ToString() == pressedButton)
            {
                typedWord += pressedButton;
                currentWordIndex++;

                myCurrentTarget.WriteText(typedWord);
            }
            else
            {
                Debug.LogErrorFormat("word doesn't contain letter {0}", pressedButton);
            }

            if (typedWord.Length >= wordToType.Length)
            {
                RandomizeNewWord();
            }
        }
    }
}
