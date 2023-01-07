using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    private GameObject _shootingAim;
    private PCInput PCI;
    private SpriteRenderer _sr;
    private Quaternion _rotation;
    private Rigidbody2D _rb;
    void Start()
    {
        if(PCI == null)
        {
            PCI = GetComponent<PCInput>();
        }
        PCI.IE.AddListener(handleLook);
        PCI.IE.AddListener(handleShoot);

        _shootingAim = GameObject.Find("Shooty shoot");
        
        _rb = _shootingAim.GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }
    private void handleLook(InputEventArgs IEA)
    {
        this._rb.rotation = IEA.lookAngle;
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
        _rotation = Quaternion.Euler(0, 0, IEA.lookAngle);
        if(IEA.leftClick)
        {
            Instantiate(_bullet, transform.localPosition, _rotation);
        }
    }
}
