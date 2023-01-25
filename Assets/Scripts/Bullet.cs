using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    private float _duration = 0;
    private Animator _animator;
    private Health _health;
    private bool _isDead;
    private void Start() {
        this._animator = GetComponent<Animator>();
        this._animator.Rebind();
    }

    void Update()
    {
        handleSpeed();
        handleDestroy();
    }

    void handleSpeed(){
        Vector2 bulletNEOW = new Vector2(bulletSpeed * Time.deltaTime, 0.0f);
        transform.Translate(bulletNEOW);
    }
    void handleDestroy()
    {
        
        this._duration += Time.deltaTime;
        if(this._duration >= 5.0f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == this.gameObject.tag) {return;}
        Destroy(this.gameObject);
    }
}
