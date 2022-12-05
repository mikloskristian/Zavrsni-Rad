using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    GameObject player;
    float bulletDamage;
    enemyShooting eS;

    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        handleSpeed();
        StartCoroutine(handleDestroy());
    }

    void handleSpeed(){
        Vector2 bulletNEOW = new Vector2(bulletSpeed * Time.deltaTime, 0.0f);
        transform.Translate(bulletNEOW);
    }

    IEnumerator handleDestroy(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            ref float enemyHealth = ref other.gameObject.GetComponent<enemyShooting>().health;
            bulletDamage = player.GetComponentInChildren<handleShooting>().damage;
            enemyHealth -= bulletDamage;
            Debug.Log(enemyHealth);
            if(enemyHealth <= 0){
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
        else if(other.tag == "Wall"){
            Destroy(gameObject);
        }
    }

    void playerAttack(float damage, ref float health){
        health -= damage;
    }
}
