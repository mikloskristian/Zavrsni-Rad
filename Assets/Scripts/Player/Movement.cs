using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private EntityScriptableObject _eso;
    PCInput PCI;
    private float _moveHoritontal;
    private float _moveVertical;
    private float _speed;
    private SpriteRenderer _sr;
    void Start()
    {
        this._sr = GetComponent<SpriteRenderer>();

        if (PCI == null)
        {
            PCI = GetComponent<PCInput>();
        }
        PCI.IE.AddListener(handleMovement);

        this._speed = _eso.getSpeed();
    }

    private void handleMovement(InputEventArgs IEA)
    {
        this._moveHoritontal = IEA.x * _speed * Time.deltaTime;
        this._moveVertical = IEA.y * _speed * Time.deltaTime;
        transform.Translate(new Vector2(_moveHoritontal, _moveVertical));
    }
}
