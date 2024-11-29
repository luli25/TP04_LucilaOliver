using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] groundObstacles;

    [SerializeField]
    private GameObject[] flyingObstacles;

    private float spawnTime;

    bool gameStart = false;

    private GameObject prefabInstance_a;
    private GameObject prefabInstance_b;

    private int MaxSpawned = 2;

    void Start()
    {
        gameStart = true;
        spawnTime = Random.Range(1f, 3f);

        StartCoroutine(SpawnEnemies());
    }

    private void SpawnObstacles()
    {
        Vector3 spawnPos = new Vector3(14, -1.06f, 0);

        int randomNumber = Random.Range(0, groundObstacles.Length);
        prefabInstance_a = Instantiate(groundObstacles[randomNumber], transform.position, transform.rotation);
        prefabInstance_b = Instantiate(flyingObstacles[randomNumber], spawnPos, transform.rotation);
        Destroy(prefabInstance_a, 10f);
        Destroy(prefabInstance_b, 10f);

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
