using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] groundObstacles;

    [SerializeField]
    private GameObject[] flyingObstacles;

    [SerializeField]
    private float spawnTime = 3f;

    bool gameStart = false;

    private GameObject prefabInstance;

    private int MaxSpawned = 2;

    void Start()
    {
        gameStart = true;
        StartCoroutine(SpawnEnemies());
    }

    private void SpawnObstacles()
    {
        Vector3 spawnPos = new Vector3(14, -1.06f, 0);

        int randomNumber = Random.Range(0, groundObstacles.Length);
        prefabInstance = Instantiate(groundObstacles[randomNumber], transform.position, transform.rotation);
        prefabInstance = Instantiate(flyingObstacles[randomNumber], spawnPos, transform.rotation);
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
