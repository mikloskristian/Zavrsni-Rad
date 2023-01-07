using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TriggerEnter))]
public class Health : MonoBehaviour
{
    [SerializeField] private EntityScriptableObject[] _eso;
    private TriggerEnter _te;
    private float _health;
    void Start()
    {
        int rnd = Random.Range(0, _eso.Length);
        if(_te == null)
        {
            _te = GetComponent<TriggerEnter>();
        }
        _te.DE.AddListener(onChange);
        this._health = _eso[rnd].getHealth();
    }

    void onChange(Damage damage){
        _health -= damage.damage;
        if(_health <= 0)
        {
            Debug.Log("mrtav");
            Destroy(gameObject);
        }
    }
}
