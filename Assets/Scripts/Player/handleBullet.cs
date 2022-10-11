using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletDamage;
    playerMovement pm;

    void Start(){
        pm = gameObject.AddComponent<playerMovement>();
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
            Debug.Log("Unisten");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(other.tag == "Wall"){
            Destroy(gameObject);
        }
    }
}
