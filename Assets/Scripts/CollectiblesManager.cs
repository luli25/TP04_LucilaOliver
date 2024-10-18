using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] collectibles;

    [SerializeField]
    private float[] spawnPercentages;

    private float timeToSpawn = 8f;

    private bool isGameStarted = false;

    private GameObject instance;

    void Start()
    {
        isGameStarted = true;
        StartCoroutine(Collectibles());

    }

    private void SpawnCollectibles()
    {
        float randomValue = Random.Range(0f, 100f);
        float cumulativeProbability = 0f;

        for(int i = 0; i < collectibles.Length; i++)
        {
            cumulativeProbability += spawnPercentages[i];

            if(randomValue <= cumulativeProbability)
            {
                instance = Instantiate(collectibles[i], transform.position, transform.rotation);
                break;
            }
        }

        Destroy(instance, 10f);
    }

    IEnumerator Collectibles()
    {
        while(isGameStarted)
        {
            yield return new WaitForSeconds(timeToSpawn);
            SpawnCollectibles();
        }
    }
}
