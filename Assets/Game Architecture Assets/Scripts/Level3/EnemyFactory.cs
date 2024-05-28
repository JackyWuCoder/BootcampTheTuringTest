using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject goblin;
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private int maxEnemies = 12;

    public void SpawnEnemyRandomly()
    {
        Transform randomSpawnPoint = GetRandomSpawnPoint();
        goblin.transform.position = randomSpawnPoint.position;
        for (int i = 0; i < maxEnemies; i++)
        {
            randomSpawnPoint = GetRandomSpawnPoint();
            SpawnEnemy(randomSpawnPoint.position);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);
        return spawnPoints[randomIndex];
    }

    private void SpawnEnemy(Vector3 position)
    {
        GameObject enemyPrefab = null;
        int randomNumber = Random.Range(0, enemyPrefabs.Count);
        enemyPrefab = enemyPrefabs[randomNumber];
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, position, Quaternion.identity);
        }
    }
}
