using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleEnemySpawning : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemy;

    

    void Start()
    {
        InvokeRepeating("enemySpawn", 1, 2);
    }

    void Update()
    {
        
    }

    void enemySpawn(){ 
        for (int i = 0; i < 4; i++){
            int randEnemy = Random.Range(0, enemy.Length);
            int randSpawn = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy[randEnemy], spawnPoints[randSpawn].position + new Vector3(0, 0, 10), transform.localRotation);
        }
    }
}
