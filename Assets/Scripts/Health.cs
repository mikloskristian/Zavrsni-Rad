using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TriggerEnter))]
public class Health : MonoBehaviour
{
    private ScriptableObjectLoader _sol;
    private TriggerEnter _te;
    private float _health;
    void Start()
    {
        this._sol = GetComponent<ScriptableObjectLoader>();

        if(_te == null)
        {
            _te = GetComponent<TriggerEnter>();
        }
        _te.DE.AddListener(onChange);

        this._health = _sol.Health;
    }

    void onChange(Damage damage){
        _health -= damage.damage;
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
