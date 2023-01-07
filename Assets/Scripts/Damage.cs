using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private EntityScriptableObject[] _eso; 
    [HideInInspector] public float damage;

    private void Start() {
        int rnd = Random.Range(0, _eso.Length);
        this.damage = _eso[rnd].getDamage();
    }
}
