using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    private GameObject _player;
    private GameObject _esr;

    private Vector2 _playerCoordinates;
    private Vector2 _lookPosition;
    private float _lookAngle;
    private Rigidbody2D _rb;
    //rotirat rb ovisno o look angleu


    //pucaj cetnike

    private void Start() {
        _player = GameObject.Find("Player");
        _esr = GameObject.Find("Enemy Shooting Rotation");
        _rb = _esr.GetComponent<Rigidbody2D>();
    }
    private void Update() {
        handleRotation();
    }

    private void handleRotation()
    {
        _playerCoordinates = _player.transform.position;
        _lookPosition = _playerCoordinates - _rb.position;
        _lookAngle = Mathf.Atan2(_lookPosition.y, _lookPosition.x) * Mathf.Rad2Deg;
        _rb.rotation = _lookAngle;
    }
}
