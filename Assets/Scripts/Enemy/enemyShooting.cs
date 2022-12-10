using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{
    [SerializeField] GameObject a;
    [SerializeField] handleShooting hS;
    [SerializeField] playerMovement pM;
    [HideInInspector] public float health;
    [HideInInspector] public float damage;
    [HideInInspector] public int score;
    bool isShooting;
    IFightable Fightable;
    enemyGetter eG;
    CircleCollider2D cC;
    
    void Start()
    {
        eG = GetComponent<enemyGetter>();
        cC = GetComponentInChildren<CircleCollider2D>();

        damage = eG.eSO[eG.rnd].getEnemyDamage(); //Enemy damage
        health = eG.eSO[eG.rnd].getEnemyHealth();
        score = eG.eSO[eG.rnd].getEnemyScore();
        isShooting = eG.eSO[eG.rnd].getIsShooting();

        cC.enabled = false;


        if(eG.rnd == 2)
        {
            IFightable Shoot = new shootingUnit();
            Shoot.Attack(damage, ref hS.health, cC);
        }
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Fightable = new groundUnit();
            Fightable.Attack(damage, ref hS.health, cC); 
        }
    }
}
