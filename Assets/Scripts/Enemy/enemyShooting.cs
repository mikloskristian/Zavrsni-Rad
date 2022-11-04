using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{
    [SerializeField] GameObject a;
    [SerializeField] handleShooting hS;
    [SerializeField] playerMovement pM;
    [HideInInspector] public float health;
    float damage;
    bool isShooting;
    IFightable IFGround;
    IFightable IFShooting;
    enemyGetter eG;
    
    void Start()
    {
        eG = GetComponent<enemyGetter>();
        damage = eG.eSO[eG.rnd].getEnemyDamage(); //Enemy damage
        health = eG.eSO[eG.rnd].getEnemyHealth();
        isShooting = eG.eSO[eG.rnd].getIsShooting();

        IFGround = new groundUnit();
        IFShooting = new shootingUnit();

        Debug.Log(health);

        //if(eG.rnd == 2)
        //{
        //    IFShooting.Attack(damage, health, a);
        //}
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            IFGround.Attack(damage, ref hS.health, a); 
            if(hS.health <= 0){
                pM.isAlive = false;
                hS.enabled = false;
                Debug.Log("Dead");
            }
        }
    }
}
