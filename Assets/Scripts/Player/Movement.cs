using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private EntityScriptableObject[] _ESO;
    [SerializeField] private GameObject _shooter;
    [SerializeField] private GameObject _bullet;
    PCInput PCI;
    private float _moveHoritontal;
    private float _moveVertical;
    private float _speed;
    private SpriteRenderer _sr;
    private Rigidbody2D _rb;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _rb = _shooter.GetComponent<Rigidbody2D>();

        if (PCI == null)
        {
            PCI = GetComponent<PCInput>();
        }
        PCI.IE.AddListener(handleMovement);
        PCI.IE.AddListener(handleLook);
        PCI.IE.AddListener(handleShoot);

        int rnd = Random.Range(0, _ESO.Length);
        _speed = _ESO[rnd].getSpeed();
    }

    private void handleMovement(InputEventArgs IEA)
    {
        _moveHoritontal = IEA.x * _speed * Time.deltaTime;
        _moveVertical = IEA.y * _speed * Time.deltaTime;
        transform.Translate(new Vector2(_moveHoritontal, _moveVertical));
    }

    private void handleLook(InputEventArgs IEA)
    {
        _rb.rotation = IEA.lookAngle;
        if(IEA.flipX < 0)
        {
            _sr.flipX = true;
        }
        else
        {
            _sr.flipX = false;
        }
    }

    private void handleShoot(InputEventArgs IEA)
    {
        if(IEA.leftClick)
        {
            Instantiate(_bullet, transform.position, _shooter.transform.localRotation);
        }
    }
}
