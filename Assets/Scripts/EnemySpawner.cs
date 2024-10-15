using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject collectiblePrefab;

    [SerializeField]
    private GameObject despawner;

    private GameObject enemyPrefabIntance;

    private GameObject collectiblePrefabIntance;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
