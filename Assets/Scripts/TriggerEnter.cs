using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnter : MonoBehaviour
{
    public DamageEvent DE;
    private void OnTriggerEnter2D(Collider2D other) {
        Damage dmg = other.GetComponent<Damage>();
        if(!dmg) return;
        DE.Invoke(dmg);
    }
}

[System.Serializable]
public class DamageEvent : UnityEvent<Damage>{}
