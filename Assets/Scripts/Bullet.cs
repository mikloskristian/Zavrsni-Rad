using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    void Start(){

    }

    void Update()
    {
        handleSpeed();
    }

    void handleSpeed(){
        Vector2 bulletNEOW = new Vector2(bulletSpeed * Time.deltaTime, 0.0f);
        transform.Translate(bulletNEOW);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == this.gameObject.tag) {return;}
        Destroy(this.gameObject);
    }
}
