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

    Vector2 mouseCoords;
    Vector2 lookPos;

    void Start()
    {

    }

    void Update()
    {
        handleMouseRotation();
        handleShoot();
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
}
