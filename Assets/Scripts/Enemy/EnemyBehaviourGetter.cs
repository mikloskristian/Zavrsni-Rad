using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehaviourGetter : MonoBehaviour
{
    private AIPath _path;
    private bool _isShootableType;
    private ScriptableObjectLoader _sol;
    private ShootingBehaviour _sb;
    void Start()
    {
        _path = GetComponent<AIPath>();
        _sol = GetComponent<ScriptableObjectLoader>();
        _sb = GetComponent<ShootingBehaviour>();


        this._sb.enabled = false;
        this._path.maxSpeed = _sol.Speed;
        this._path.radius = _sol.AIPathRadius;
        this._isShootableType = _sol.IsShootableType;


        if(_isShootableType)
        {
            _sb.enabled = true;
        }
    }
}
