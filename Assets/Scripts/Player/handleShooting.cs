using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleShooting : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] GameObject fireball;
    [SerializeField] GameObject player;
    [SerializeField] Camera cam;

    [Header("Components")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;

    [Header("Health and Damage")]
    [SerializeField] public float health;
    [SerializeField] public float damage;

    Vector2 mouseCoords;
    Vector2 lookPos;
    playerMovement pM;
    handleShooting hS;

    void Start()
    {
        pM = GetComponentInParent<playerMovement>();
        hS = GetComponent<handleShooting>();
    }

    void Update()
    {
        handleMouseRotation();
        handleShoot();
        handleDeath();
    }

    void handleMouseRotation(){
        mouseCoords = cam.ScreenToWorldPoint(Input.mousePosition);
        lookPos = mouseCoords - rb.position;
        float lookAngle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        rb.rotation = lookAngle;

        if (lookPos.x > 0){
            sr.flipX = false;
        }
        else{
            sr.flipX = true;
        }
    }
    void handleShoot() {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            GameObject bullet = Instantiate(fireball, player.transform.localPosition, transform.localRotation);
        }
    }
    void handleDeath()
    {
        if(health <= 0){
                pM.isAlive = false;
                hS.enabled = false;
                Debug.Log("Dead");
            }
    }
}
