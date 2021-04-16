using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    public GameObject asteroid;

    public GameObject[] spawnpoints;

    public float timeToSpawn;
    private float originalTimeToSpawn;

    int lastIndex = 0;

    void Start()
    {
        originalTimeToSpawn = timeToSpawn;
    }

    void Update()
    {
        if (timeToSpawn <= 0)
        {
            int positionIndex = Random.Range(0, spawnpoints.Length);

            while (positionIndex == lastIndex)
            {
                positionIndex = Random.Range(0, spawnpoints.Length);
            }

            GameObject position = spawnpoints[positionIndex];
            Instantiate(asteroid, position.transform.position, Quaternion.identity);

            lastIndex = positionIndex;
            timeToSpawn = originalTimeToSpawn;
        }
        else
        {
            timeToSpawn -= Time.deltaTime;
        }
    }
}
