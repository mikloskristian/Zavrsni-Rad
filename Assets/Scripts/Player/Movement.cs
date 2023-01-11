using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private ScriptableObjectLoader _sol;
    private PCInput _pci;
    private float _moveHoritontal;
    private float _moveVertical;
    private float _speed;
    private SpriteRenderer _sr;
    void Start()
    {
        this._sr = GetComponent<SpriteRenderer>();
        this._sol = GetComponent<ScriptableObjectLoader>();

        if (_pci == null)
        {
            _pci = GetComponent<PCInput>();
        }
        _pci.IE.AddListener(handleMovement);

        this._speed = _sol.Speed;
    }

    private void handleMovement(InputEventArgs IEA)
    {
        this._moveHoritontal = IEA.x * _speed * Time.deltaTime;
        this._moveVertical = IEA.y * _speed * Time.deltaTime;
        transform.Translate(new Vector2(_moveHoritontal, _moveVertical));
    }
}
