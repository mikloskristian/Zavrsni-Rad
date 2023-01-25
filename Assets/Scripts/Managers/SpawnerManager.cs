using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    private int _waveEnemyAmmount = 2;
    private float _spawnTimer = 5.0f;
    private ObjectPooler _objectPooler;
    private TimerEvent _te;

    void Start()
    {
        _objectPooler = ObjectPooler.Instance;
        InvokeRepeating("enemySpawn", 2.0f, _spawnTimer);
        _te = GetComponent<TimerEvent>();
        _te.SE.AddListener(handleWaveUpdate);
    }

    void Update()
    {
        
    }

    void enemySpawn(){ 
        for (int i = 0; i < _waveEnemyAmmount; i++){
            int randSpawn = Random.Range(0, spawnPoints.Length);
            _objectPooler.SpawnFromPool("Enemy", spawnPoints[randSpawn].position + new Vector3(0, 0, 10.0f), Quaternion.identity);
        }
    }

    public void handleWaveUpdate(bool isUpdateable)
    {
        isUpdateable = _te.TimerUpdate;
        if(isUpdateable)
        {
            _waveEnemyAmmount++;
            _spawnTimer -= 0.15f;
        }
    }
}
