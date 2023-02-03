using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private ScriptableObjectLoader _sol;
    private PCInput _pci;
    private Health _health;
    private float _moveHoritontal;
    private float _moveVertical;
    private float _speed;
    private SpriteRenderer _sr;
    private bool _isDead = false;
    void Start()
    {
        this._sr = GetComponent<SpriteRenderer>();
        this._sol = GetComponent<ScriptableObjectLoader>();
        this._health = GetComponent<Health>();
        this._pci = GetComponent<PCInput>();

        _pci.IE.AddListener(handleMovement);
        _health.DE.AddListener(handleDeath);

        this._speed = _sol.Speed;
    }

    private void handleMovement(InputEventArgs IEA)
    {
        if(_isDead){return;}
        else
        {
            this._moveHoritontal = IEA.x * _speed * Time.deltaTime;
            this._moveVertical = IEA.y * _speed * Time.deltaTime;
            transform.Translate(new Vector2(_moveHoritontal, _moveVertical));
        }
    }
    private void handleDeath(bool isDead)
    {
        this._isDead = isDead;
    }
}
