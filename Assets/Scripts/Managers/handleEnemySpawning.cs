using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleEnemySpawning : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [HideInInspector] public int WaveEnemyAmmount = 3;
    private ObjectPooler _objectPooler;

    void Start()
    {
        _objectPooler = ObjectPooler.Instance;
        InvokeRepeating("enemySpawn", 2.0f, 4.0f);
    }

    void Update()
    {
        
    }

    void enemySpawn(){ 
        for (int i = 0; i < 4; i++){
            int randSpawn = Random.Range(0, spawnPoints.Length);
            _objectPooler.SpawnFromPool("Enemy", spawnPoints[randSpawn].position + new Vector3(0, 0, 10.0f), Quaternion.identity);
        }
    }
}
