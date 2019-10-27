using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 10f;

    static public List<Enemy> SpawnedEnemies { get; private set; } = new List<Enemy>();

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (Application.isPlaying)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 10));
            SpawnedEnemies.Add(enemy.GetComponent<Enemy>());

            yield return new WaitForSeconds(spawnRate);
        }
    }

    static public Enemy FetchEnemyMatchingLetter(string letter)
    {
        for (int i = 0; i < SpawnedEnemies.Count; i++)
        {
            // Find the matching first letter
            if (SpawnedEnemies[i].myText[0].ToString() == letter)
            {
                Debug.Log("found enemy with matching letter");
                return SpawnedEnemies[i];
            }
        }
        Debug.LogErrorFormat("could not find enemy with letter {0}", letter);
        return null;
    }
}
