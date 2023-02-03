using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnter : MonoBehaviour
{
    public DamageEvent DE;
    private Health _health;
    private bool _isDead;
    [HideInInspector] public BoxCollider2D BC;
    private void Start() 
    {
        if (DE == null)
        {
            this.DE = new DamageEvent();
        }
        this._health = GetComponent<Health>();
        this._health.DE.AddListener(handleDeath);
        this.BC = GetComponent<BoxCollider2D>();

    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Damage dmg = other.GetComponent<Damage>();
        if(!dmg || gameObject.tag == other.gameObject.tag){return;}
        DE.Invoke(dmg);
    }

    private void handleDeath(bool isDead)
    {
        this._isDead = isDead;
    }

    private void Update() {
        if(_isDead)
        {
            BC.enabled = false;
        }
        else
        {
            BC.enabled = true;
        }
    }
}

[System.Serializable]
public class DamageEvent : UnityEvent<Damage>{}
