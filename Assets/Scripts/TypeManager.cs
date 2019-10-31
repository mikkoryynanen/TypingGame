using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeManager : MonoBehaviour
{
    public Transform player;

    public MoveAlongLine moveAlong;
    public EnemySpawner enemySpawner;
    public Text currentWordText;

    int wordIndex = -1;
    string wordToType = "";
    Enemy myCurrentTarget = null;
    string typedWord = "";

    LineRenderer _line;
    AudioController _audioController;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
        _audioController = GetComponent<AudioController>();

        WordDatabase.LoadWords();   // TODO do this in word database initialization

        RandomizeNewWord();
    }

    void RandomizeNewWord()
    {
        moveAlong.ResetToDefault();

        typedWord = string.Empty;
        wordToType = "";

        enemySpawner.SpawnedEnemies.Remove(myCurrentTarget);
        myCurrentTarget = null;
        wordIndex = 0;
    }

    void Update()
    {
        if (myCurrentTarget != null)
        {
            _line.SetPosition(1, myCurrentTarget.transform.position);
        }
        else
        {
            _line.SetPosition(1, _line.GetPosition(0));
        }

        if (Input.anyKeyDown)
        {
            string pressedButton = Input.inputString;

            if (myCurrentTarget == null)
            {
                myCurrentTarget = enemySpawner.FetchEnemyMatchingLetter(pressedButton);
                wordToType = myCurrentTarget.MyWord;
            }

            if (myCurrentTarget.MyWord[wordIndex].ToString() == pressedButton)
            {
                typedWord += pressedButton;
                wordIndex++;

                myCurrentTarget.WriteText(pressedButton);

                _line.SetPosition(0, player.position);
                _line.SetPosition(1, myCurrentTarget.transform.position);

                moveAlong.targetPosition = myCurrentTarget.transform.position;
                moveAlong.Setup();

                _audioController.PlayKeySound();
            }

            if (typedWord.Length >= wordToType.Length)
            {
                RandomizeNewWord();
            }
        }
    }
}
