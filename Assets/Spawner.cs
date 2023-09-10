using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] TreePrefabs; // Change to TreePrefabs
    public GameObject EnemyPrefab;
    public GameHandler gameHandler;

    public float treeSpawnRate = 2f;
    public float enemySpawnRate = 3f;
    public float enemyReplacementInterval = 15f;

    private float nextTreeSpawn = 0f;
    private float nextEnemySpawn = 0f;
    private float nextEnemyReplacement = 0f;

    public Transform[] treeSpawnPoints;
    public Transform[] enemySpawnPoints;

    public Rect exclusionZone; // Define the exclusion zone

    private List<GameObject> spawnedTrees = new List<GameObject>();
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private void OnDrawGizmos()
    {
        // Draw the exclusion zone in the Scene view Gizmos
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(exclusionZone.center, exclusionZone.size);
    }

    void Update()
    {
        // Spawn trees
        if (Time.time > nextTreeSpawn && spawnedTrees.Count < 10)
        {
            nextTreeSpawn = Time.time + treeSpawnRate;
            int randomIndex;
            Vector3 spawnPosition;

            // Generate a random position outside the exclusion zone
            do
            {
                randomIndex = Random.Range(0, treeSpawnPoints.Length);
                spawnPosition = treeSpawnPoints[randomIndex].position;
            } while (exclusionZone.Contains(spawnPosition));

            // Randomly select a tree prefab from the array
            GameObject selectedTreePrefab = TreePrefabs[Random.Range(0, TreePrefabs.Length)];

            GameObject newTree = Instantiate(selectedTreePrefab, spawnPosition, Quaternion.identity);
            spawnedTrees.Add(newTree);
        }

        // Spawn enemies
        if (Time.time > nextEnemySpawn && spawnedEnemies.Count < 5)
        {
            nextEnemySpawn = Time.time + enemySpawnRate;
            int randomIndex;
            Vector3 spawnPosition;

            // Generate a random position outside the exclusion zone
            do
            {
                randomIndex = Random.Range(0, enemySpawnPoints.Length);
                spawnPosition = enemySpawnPoints[randomIndex].position;
            } while (exclusionZone.Contains(spawnPosition));

            GameObject newEnemy = Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            spawnedEnemies.Add(newEnemy);
        }

        // Check if any enemies are not in the camera view and replace them
        if (Time.time > nextEnemyReplacement)
        {
            nextEnemyReplacement = Time.time + enemyReplacementInterval;
            for (int i = spawnedEnemies.Count - 1; i >= 0; i--)
            {
                if (!IsInCameraView(spawnedEnemies[i].transform.position))
                {
                    Destroy(spawnedEnemies[i]);
                    spawnedEnemies.RemoveAt(i);
                }
            }
        }
    }

    // Helper function to check if a position is in the camera view
    bool IsInCameraView(Vector3 position)
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }
}
