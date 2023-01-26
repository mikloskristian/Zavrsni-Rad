using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Slider _slider;
    private GameObject _player;
    private Health _h;
    void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    void Start() {
        _player = GameObject.Find("Player");
        _h = _player.GetComponent<Health>();
        _h.HE.AddListener(getHealth); 
        _h.DE.AddListener(handleDeath);
        _slider.maxValue = 10.0f;
        _slider.value = 10.0f;
    }
    private void Update() {
        
    }
    void getHealth(float _health)
    {
        _health = _h.ObjectHealth;
        HealthManager.Instance.SetHealthValue(_health, _slider);
        _h.HE.RemoveListener(getHealth);
        _h.HE.AddListener(removeHealth);
    }
    void removeHealth(float _health)
    {
        _health = _h.ObjectHealth;
        HealthManager.Instance.RemoveHealthValue(_health, _slider);
    }
    private void handleDeath(bool isDead)
    {
        _slider.value = 0;
    }
}
