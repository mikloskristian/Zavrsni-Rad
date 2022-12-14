using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IObserver
{ 
    public float damage;
    public float health;
    private EnemyDamage enemyDamage;
    public PlayerHealth(EnemyDamage enemyDamage)
    {
        this.enemyDamage = enemyDamage;
    }
    public void Update(float damage)
    {
        this.damage = damage;
        health -= damage;
    }
}
