using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    private GameObject _shootingAim;
    private PCInput PCI;
    private Health _health;
    private SpriteRenderer _sr;
    private Quaternion _rotation;
    private Rigidbody2D _rb;
    private bool _isDead;
    void Start()
    {
        this._shootingAim = GameObject.Find("Player Shooting Rotation");
        
        this._rb = _shootingAim.GetComponent<Rigidbody2D>();
        this._sr = GetComponent<SpriteRenderer>();
        this._health = GetComponent<Health>();
        this.PCI = GetComponent<PCInput>();

        this.PCI.IE.AddListener(handleLook);
        this.PCI.IE.AddListener(handleShoot);
        this._health.DE.AddListener(handleDeath);
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
        if(_isDead){return;}
        else
        {
            _rotation = Quaternion.Euler(0, 0, IEA.lookAngle);
            if(IEA.leftClick)
            {
                GameObject go = Instantiate(_bullet, transform.localPosition, _rotation);
                go.gameObject.tag = "Player";
            }
        }
    }
    private void handleDeath(bool isDead)
    {
        this._isDead = isDead;
    }
}
