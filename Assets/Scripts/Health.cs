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
    public DeathEvent DE;
    private Animator _animator;
    [HideInInspector] public bool IsDead = false;
    [HideInInspector] public float ObjectHealth;
    [HideInInspector] public float EnemyScore;
    private float _score;
    private void Awake() {
        if(HE == null)
        {
            this.HE = new HealthbarEvent();
        }
        if(DE == null)
        {
            this.DE = new DeathEvent();
        }
    }
    void Start()
    {
        this._sol = GetComponent<ScriptableObjectLoader>();
        this._animator = GetComponent<Animator>();
        this._te = GetComponent<TriggerEnter>();

        this._te.DE.AddListener(onChange);

        this.ObjectHealth = _sol.Health;
        this._score = _sol.Score;
        this.HE.Invoke(ObjectHealth);
    }

    void onChange(Damage damage){
        this.ObjectHealth -= damage.damage;
        if(this.ObjectHealth <= 0)
        {
            if(IsDead){return;}
            else
            {
                if(gameObject.tag == "Enemy")
                {
                    EnemyScore = gameObject.GetComponent<Health>()._score;
                    ScoreLoader.Instance.updateScore(EnemyScore);
                }
                DE.Invoke(true);
                StartCoroutine("Death");
            }
            this.IsDead = true;
        }
        else
        {
            _animator.SetTrigger("IsHit");
        
            if(gameObject.tag == "Player")
            {
                HE.Invoke(ObjectHealth);
            }
        }
    }
    private IEnumerator Death()
    {
        _animator.SetTrigger("IsDead");
        yield return new WaitForSeconds(2.0f);
        this.gameObject.SetActive(false);
    }
}
[System.Serializable]
public class HealthbarEvent : UnityEvent<float>{}
public class DeathEvent : UnityEvent<bool>{}
