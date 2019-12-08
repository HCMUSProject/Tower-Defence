using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 12f)]
    [SerializeField]
    float secondsBetweenSpawns = 6f;
    [SerializeField]
    EnemyMovement enemyPrefab;

    [SerializeField]
    Transform enemyParentTransform;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            var Enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Enemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
