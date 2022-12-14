using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletDamage : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] public EnemyDamage enemyDamage;
    IObserver playerhealthVariable;
    GameObject enemy;
    float bulletDamage;
    bool yes;
    enemyShooting eS;
    private void Start(){
        enemy = GameObject.FindWithTag("Enemy");
        enemyDamage = new EnemyDamage();
        enemyDamage.Add(playerhealthVariable);
    }

    private void Update()
    {
        handleSpeed();
        StartCoroutine(handleDestroy());
    }

    private void handleSpeed(){
        Vector2 bulletTrajectory = new Vector2(bulletSpeed * Time.deltaTime, 0.0f);
        transform.Translate(bulletTrajectory);
    }

    private IEnumerator handleDestroy(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            //ref float playerHealth = ref other.gameObject.GetComponentInChildren<handleShooting>().health;
            //bulletDamage = enemy.GetComponent<enemyShooting>().damage;
            //playerHealth -= bulletDamage;
            enemyDamage.Notify();
            Destroy(gameObject);
        }
        else if(other.tag == "Wall"){
            Destroy(gameObject);
        }
    }
}
