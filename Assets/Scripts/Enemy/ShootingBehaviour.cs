using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ShootingBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    private GameObject _player;
    [SerializeField] private GameObject _enemy;

    private Vector2 _playerCoordinates;
    private Vector2 _lookPosition;
    private float _lookAngle;
    private float time;
    private Rigidbody2D _rb;

    private AIPath _path;

    private void Start() {
        _player = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody2D>();
        _path = _enemy.GetComponentInChildren<AIPath>();

        _rb.bodyType = RigidbodyType2D.Kinematic;
    }
    private void Update() {
        handleRotation();
        handleDistance();
    }

    private void handleRotation()
    {
        if(_player != null)
        {
            _playerCoordinates = _player.transform.position;
            _lookPosition = _playerCoordinates - _rb.position;
            _lookAngle = Mathf.Atan2(_lookPosition.y, _lookPosition.x) * Mathf.Rad2Deg;
            _rb.rotation = _lookAngle;
        }
    }

    private void handleShooting()
    {  
        GameObject metak = Instantiate(_bullet, gameObject.transform.position, Quaternion.Euler(0, 0, _lookAngle));
        metak.gameObject.tag = "Enemy";
    }

    private void handleDistance()
    {
        if(_path.remainingDistance <= 16.0f)
        {
            time += Time.deltaTime;
            if(time >= 3.0f)
            {
                time = 0.0f;
                handleShooting();
            }
        }
        return;
    }
}
