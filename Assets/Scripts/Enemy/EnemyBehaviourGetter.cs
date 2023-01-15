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
    void Start()
    {
        _player = GameObject.Find("Player");

        _path = GetComponent<AIPath>();
        _sol = GetComponent<ScriptableObjectLoader>();
        _sb = GetComponentInChildren<ShootingBehaviour>();


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
        this._path.destination = _player.transform.position;
    }
}
