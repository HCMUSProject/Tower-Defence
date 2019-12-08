using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 12f)]
    [SerializeField]
    float secondsBetweenSpawns = 6f;
    [SerializeField]
    EnemyMovement enemyPrefab;

    [SerializeField]
    Transform enemyParentTransform;

    [SerializeField]
    Text spawnedEnemies;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnedEnemies.text = score.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            IncreaseScore();
            var Enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Enemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void IncreaseScore()
    {
        score++;
        spawnedEnemies.text = score.ToString();
    }
}
