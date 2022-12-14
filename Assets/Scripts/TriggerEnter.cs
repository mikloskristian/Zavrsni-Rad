using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnter : MonoBehaviour
{
    public DamageEvent DE;
    private void Start() 
    {
        if (DE == null){
            DE = new DamageEvent();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Damage dmg = other.GetComponent<Damage>();
        if(!dmg || gameObject.tag == other.gameObject.tag) return;
        DE.Invoke(dmg);
    }
}

[System.Serializable]
public class DamageEvent : UnityEvent<Damage>{}
