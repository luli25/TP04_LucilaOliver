using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;

    [SerializeField]
    private GameObject endLevel;

    [SerializeField]
    private float spawnTime = 3f;

    bool gameStart = false;

    private GameObject prefabInstance;

    private bool MaxSpawned;

    void Start()
    {
        gameStart = true;
        StartCoroutine(SpawnEnemies());
    }

    private void SpawnObstacles()
    {

        int randomNumber = Random.Range(0, obstacles.Length);
        prefabInstance = Instantiate(obstacles[randomNumber], transform.position, transform.rotation);

    }

    IEnumerator SpawnEnemies()
    {
        while (gameStart)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnObstacles();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("endLevel"))
        {
            Destroy(prefabInstance, 0);
            Debug.Log("Instance destroyed");
        }
    }
}
