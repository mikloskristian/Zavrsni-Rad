using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TriggerEnter))]
public class Health : MonoBehaviour
{
    private ScriptableObjectLoader _sol;
    private TriggerEnter _te;
    public HealthbarEvent HE;
    private float _health;
    void Start()
    {
        this._sol = GetComponent<ScriptableObjectLoader>();

        if(_te == null)
        {
            _te = GetComponent<TriggerEnter>();
        }
        if(HE == null)
        {
            HE = new HealthbarEvent();
        }
        _te.DE.AddListener(onChange);

        this._health = _sol.Health;
    }

    void onChange(Damage damage){
        _health -= damage.damage;
        if(gameObject.tag == "Player")
        {
            HE.Invoke(_health);
        }
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
[System.Serializable]
public class HealthbarEvent : UnityEvent<float>{}
