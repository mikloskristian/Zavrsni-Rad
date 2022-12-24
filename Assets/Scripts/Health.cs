using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TriggerEnter))]
public class Health : MonoBehaviour
{
    private TriggerEnter _te;
    [SerializeField] float health;
    void Start()
    {
        if(_te == null)
        {
            _te = GetComponent<TriggerEnter>();
        }
        _te.DE.AddListener(onChange);
    }

    void onChange(Damage damage){
        health -= damage.damage;
        if(health <= 0)
        {
            Debug.Log("mrtav");
        }
    }
}
