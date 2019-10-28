using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public Text currentWordText;

    string wordToType = "";
    Enemy myCurrentTarget = null;
    string typedWord = "";

    private void Start()
    {
        WordDatabase.LoadWords();   // TODO do this in word database initialization

        RandomizeNewWord();
    }

    void RandomizeNewWord()
    {
        typedWord = string.Empty;
        wordToType = "";

        enemySpawner.SpawnedEnemies.Remove(myCurrentTarget);
        myCurrentTarget = null; 
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            string pressedButton = Input.inputString;

            if (myCurrentTarget == null)
            {
                myCurrentTarget = enemySpawner.FetchEnemyMatchingLetter(pressedButton);
                wordToType = myCurrentTarget.myWord;
            }

            myCurrentTarget.WriteText(pressedButton);

            typedWord += pressedButton;
            if (typedWord.Length >= wordToType.Length)
            {
                RandomizeNewWord();
            }
        }
    }
}
