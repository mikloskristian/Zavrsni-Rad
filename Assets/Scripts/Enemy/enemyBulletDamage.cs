using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletDamage : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    GameObject enemy;
    float bulletDamage;
    enemyShooting eS;

    void Start(){
        enemy = GameObject.FindWithTag("Enemy");
    }

    void Update()
    {
        handleSpeed();
        StartCoroutine(handleDestroy());
    }

    void handleSpeed(){
        Vector2 bulletTrajectory = new Vector2(bulletSpeed * Time.deltaTime, 0.0f);
        transform.Translate(bulletTrajectory);
    }

    IEnumerator handleDestroy(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            ref float playerHealth = ref other.gameObject.GetComponentInChildren<handleShooting>().health;
            bulletDamage = enemy.GetComponent<enemyShooting>().damage;
            playerHealth -= bulletDamage;
            Destroy(gameObject);
        }
        else if(other.tag == "Wall"){
            Destroy(gameObject);
        }
    }
}
