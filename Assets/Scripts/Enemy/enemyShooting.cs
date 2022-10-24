using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{
    [SerializeField] GameObject a;
    [SerializeField] playerMovement pM;
    float health;
    float damage;
    bool isShooting;
    IFightable IFGround;
    IFightable IFShooting;
    enemyGetter eG;
    
    void Start()
    {
        eG = GetComponent<enemyGetter>();
        health = pM.health; //Player health
        damage = eG.eSO[eG.rnd].getEnemyDamage(); //Enemy damage
        isShooting = eG.eSO[eG.rnd].getIsShooting();

        IFGround = new groundUnit();
        IFShooting = new shootingUnit();

        if(eG.rnd == 2)
        {
            IFShooting.Attack(damage, health, a);
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            IFGround.Attack(damage, health, a);
            Debug.Log(health);
        }
    }
}
