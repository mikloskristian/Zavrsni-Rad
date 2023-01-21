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
    public ScoreEvent SE;
    public float ObjectHealth;
    public float EnemyScore;
    private float _score;
    private bool _isDead;
    private void Awake() {
        if(_te == null)
        {
            _te = GetComponent<TriggerEnter>();
        }
        if(HE == null)
        {
            HE = new HealthbarEvent();
        }
        if(SE == null)
        {
            SE = new ScoreEvent();
        }
    }
    void Start()
    {
        this._sol = GetComponent<ScriptableObjectLoader>();

        _te.DE.AddListener(onChange);

        this.ObjectHealth = _sol.Health;
        this._score = _sol.Score;
        this._isDead = false;
        HE.Invoke(ObjectHealth);
    }

    void onChange(Damage damage){
        ObjectHealth -= damage.damage;
        if(gameObject.tag == "Player")
        {
            HE.Invoke(ObjectHealth);
            //Works if i put SE.Invoke here
        }
        if(ObjectHealth <= 0)
        {
            SE.Invoke(EnemyScore); //doesn't work here :/
            if(gameObject.tag == "Enemy")
            {
                EnemyScore = gameObject.GetComponent<Health>()._score;
            }
            Destroy(gameObject);
        }
    }
}
[System.Serializable]
public class ScoreEvent : UnityEvent<float>{}
public class HealthbarEvent : UnityEvent<float>{}
