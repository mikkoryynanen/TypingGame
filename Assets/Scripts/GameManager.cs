using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentWave = 0;
    public EnemySpawner enemySpawner;

    enum GameState
    {
        Running,
        Paused,
        GameOver
    }
    GameState gameState = GameState.Running;

    static public GameManager Instance = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(GameRoutine());
    }

    IEnumerator GameRoutine()
    {
        while (gameState == GameState.Running)
        {
            if (enemySpawner.SpawnedEnemies.Count <= 0)
            {
                enemySpawner.Spawn();
            }

            yield return null;
        }
    }

    public void GameOver()
    {
        //gameState = GameState.GameOver;
    }
}
