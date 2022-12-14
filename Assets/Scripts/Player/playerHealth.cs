using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField] public float health;
    private EnemyDamage enemyDamage;
    PlayerHealth playerHealthVariable;
    void Start()
    {
        playerHealthVariable = new PlayerHealth(enemyDamage);
    }
    private void Update() {
        Debug.Log(playerHealthVariable.damage);
    }
}
