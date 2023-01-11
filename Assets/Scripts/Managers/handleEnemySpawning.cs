using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleEnemySpawning : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemy;
    [HideInInspector] public int WaveEnemyAmmount = 3;

    void Start()
    {
        enemySpawn();
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
    //Uzet randEnemy i randSpawn i max value stavit u posebnu varijablu, napravit timer kad kucne timer da se spawna sljedeci wave, povezat sa managerom
    //Prije ovoga samo health i highscore napravis, 5 min posla samo spawn i imenuj
}
