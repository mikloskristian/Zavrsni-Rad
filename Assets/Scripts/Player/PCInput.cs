using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PCInput : MonoBehaviour
{
    [SerializeField] public EntityScriptableObject[] ESO;
    [SerializeField] private Camera _camera;
    public InputEvent IE;
    private float _moveX;
    private float _moveY;
    private float _lookAngle;
    private bool _leftClick;
    private Vector2 _mouseCoordinates;
    private Vector2 _lookPosition;
    private Rigidbody2D _rb;
    void Start()
    {
        if(IE == null)
        {
            IE = new InputEvent();
        }
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveY = Input.GetAxis("Vertical");
        _leftClick = Input.GetKeyDown(KeyCode.Mouse0);

        _mouseCoordinates = _camera.ScreenToWorldPoint(Input.mousePosition);
        _lookPosition = _mouseCoordinates - _rb.position;
        _lookAngle = Mathf.Atan2(_lookPosition.y, _lookPosition.x) * Mathf.Rad2Deg;
        
        IE.Invoke(new InputEventArgs(_moveX, _moveY, _lookAngle, _lookPosition, _leftClick));
    }
}
[System.Serializable]
public class InputEvent : UnityEvent<InputEventArgs>{}
public struct InputEventArgs
{
    public float x;
    public float y;
    public float lookAngle;
    public float flipX;
    public bool leftClick;
    public InputEventArgs(float x, float y, float lookAngle, Vector2 lookX, bool leftClick)
    {
        this.x = x;
        this.y = y;
        this.lookAngle = lookAngle;
        this.flipX = lookX.x;
        this.leftClick = leftClick;
    }
}
