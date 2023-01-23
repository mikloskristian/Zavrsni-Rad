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
    private Animator _animator;
    [HideInInspector] public float ObjectHealth;
    [HideInInspector] public float EnemyScore;
    private float _score;
    private void Awake() {
        if(_te == null)
        {
            _te = GetComponent<TriggerEnter>();
        }
        if(HE == null)
        {
            HE = new HealthbarEvent();
        }
    }
    void Start()
    {
        this._sol = GetComponent<ScriptableObjectLoader>();
        this._animator = GetComponent<Animator>();

        _te.DE.AddListener(onChange);

        this.ObjectHealth = _sol.Health;
        this._score = _sol.Score;
        HE.Invoke(ObjectHealth);
    }

    void onChange(Damage damage){
        this.ObjectHealth -= damage.damage;
        if(gameObject.tag == "Player")
        {
            HE.Invoke(ObjectHealth);
        }
        if(this.ObjectHealth <= 0)
        {
            if(gameObject.tag == "Enemy")
            {
                EnemyScore = gameObject.GetComponent<Health>()._score;
                ScoreLoader.Instance.updateScore(EnemyScore);
            }
            gameObject.SetActive(false);
        }
        
    }
}
[System.Serializable]
public class HealthbarEvent : UnityEvent<float>{}
