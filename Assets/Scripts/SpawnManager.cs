using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;

    [SerializeField]
    private float spawnTime = 3f;

    bool gameStart = false;

    private GameObject prefabInstance;

    private int MaxSpawned = 1;

    void Start()
    {
        gameStart = true;
        StartCoroutine(SpawnEnemies());
    }

    private void SpawnObstacles()
    {

        int randomNumber = Random.Range(0, obstacles.Length);
        prefabInstance = Instantiate(obstacles[randomNumber], transform.position, transform.rotation);
        Destroy(prefabInstance, 10f);

    }

    IEnumerator SpawnEnemies()
    {
        while (gameStart)
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length < MaxSpawned)
            {
                SpawnObstacles();
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
