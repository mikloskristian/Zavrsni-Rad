using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehaviourGetter : MonoBehaviour
{
    private GameObject _player;
    [HideInInspector] public AIPath Path;
    private bool _isShootableType;
    private bool _isDead;
    private ScriptableObjectLoader _sol;
    private ShootingBehaviour _sb;
    private SpriteRenderer _sr;
    private Health _health;
    void Start()
    {
        this._player = GameObject.Find("Player");

        this._health = GetComponent<Health>();
        this.Path = GetComponent<AIPath>();
        this._sol = GetComponent<ScriptableObjectLoader>();
        this._sb = GetComponentInChildren<ShootingBehaviour>();
        this._sr = GetComponent<SpriteRenderer>();

        this._sb.enabled = false;
        this.Path.maxSpeed = _sol.Speed;
        this.Path.radius = _sol.AIPathRadius;
        this._isShootableType = _sol.IsShootableType;

        this._health.DE.AddListener(handleDeath);


        if(_isShootableType)
        {
            _sb.enabled = true;
        }
    }

    void Update() {
        if(this._isDead){this.Path.enabled = false; return;}
        else
        {
            this.Path.enabled = true;
            if(_player != null)
            {
                this.Path.destination = _player.transform.position;
                if(Path.desiredVelocity.x <= 0.01f)
                {
                    this._sr.flipX = true;
                }
                else {this._sr.flipX = false;}
            }
        }
    }

    private void handleDeath(bool isDead)
    {
        this._isDead = isDead;
    }
}
