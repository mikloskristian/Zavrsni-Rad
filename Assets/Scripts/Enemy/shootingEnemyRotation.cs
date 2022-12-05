using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class shootingEnemyRotation : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    [SerializeField] GameObject enemy;
    Vector2 playerCoords;
    Vector2 lookPos;
    GameObject player;
    Rigidbody2D rb;
    IFightable IFShooting;
    enemyShooting eS;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
        rb = GetComponent<Rigidbody2D>();
        eS = GetComponentInParent<enemyShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        handleRotation();
    }

    void handleRotation()
    {
        playerCoords = player.transform.localPosition;
        lookPos = playerCoords - rb.position;
        float lookAngle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, 0, lookAngle);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
       {
            StartCoroutine(shootAtPlayer());
       }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            StopAllCoroutines();
        }
    }
    IEnumerator shootAtPlayer() 
    {
        while(true)
        {
            Instantiate(enemyBullet, enemy.transform.localPosition, transform.localRotation);
            yield return new WaitForSeconds(3.0f);
        }
    }
}
