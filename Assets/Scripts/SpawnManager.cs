using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;

    [SerializeField]
    private GameObject endLevel;

    private float respawnTime = 5.0f;

    bool gameStart = false;

    private GameObject prefabInstance;

    void Start()
    {
        gameStart = true;
        StartCoroutine(SpawnEnemies());
    }

    
    void Update()
    {
        
    }

    private void SpawnObstacles()
    {
        int randomNumber = Random.Range(0, obstacles.Length);
        prefabInstance = Instantiate(obstacles[randomNumber], transform.position, transform.rotation);
    }

    IEnumerator SpawnEnemies()
    {
        while(gameStart)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnObstacles();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("endPoint"))
        {
            Destroy(prefabInstance, 0);
        }
    }
}
