using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20.0f;

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
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    //private void OnTriggerEnter2D(Collider2D other){
    //    if(other.tag == "Enemy"){
    //        Debug.Log("Damaged!");
//            Destroy(gameObject);
    //    }
    //}
}
