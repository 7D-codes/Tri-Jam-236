using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject TreePrefab;
    public GameHandler gameHandler;

    public float spawnRate = 2f;

    private float nextSpawn = 0f;

    public Transform[] spawnPoints;

    public Rect exclusionZone; // Define the exclusion zone

    private void OnDrawGizmos()
    {
        // Draw the exclusion zone in the Scene view Gizmos
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(exclusionZone.center, exclusionZone.size);
    }

    void Update()
    {
        if (Time.time > nextSpawn && gameHandler.trees < 10)
        {
            nextSpawn = Time.time + spawnRate;
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = Vector3.zero;

            // Generate a random position within the spawn zone
            do
            {
                spawnPosition = spawnPoints[randomIndex].position;
            } while (exclusionZone.Contains(spawnPosition));

            Instantiate(TreePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
