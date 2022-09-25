using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleWallSpawnPrevention : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Wall"){
            gameObject.SetActive(false);
        } else{
            gameObject.SetActive(true);
        }
    }

}
