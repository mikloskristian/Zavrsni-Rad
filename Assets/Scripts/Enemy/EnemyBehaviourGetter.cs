using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehaviourGetter : MonoBehaviour
{
    private GameObject _player;
    private AIPath _path;
    private bool _isShootableType;
    private ScriptableObjectLoader _sol;
    private ShootingBehaviour _sb;
    private SpriteRenderer _sr;
    void Start()
    {
        _player = GameObject.Find("Player");

        this._path = GetComponent<AIPath>();
        this._sol = GetComponent<ScriptableObjectLoader>();
        this._sb = GetComponentInChildren<ShootingBehaviour>();
        this._sr = GetComponent<SpriteRenderer>();


        this._sb.enabled = false;
        this._path.maxSpeed = _sol.Speed;
        this._path.radius = _sol.AIPathRadius;
        this._isShootableType = _sol.IsShootableType;


        if(_isShootableType)
        {
            _sb.enabled = true;
        }
    }

    void Update() {
        if(_player != null)
        {
            this._path.destination = _player.transform.position;
            if(_path.desiredVelocity.x <= 0.01f)
            {
                this._sr.flipX = true;
            }
            else {this._sr.flipX = false;}
        }
    }
}
