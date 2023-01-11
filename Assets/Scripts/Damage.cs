using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [HideInInspector] public float damage;
    private ScriptableObjectLoader _sol;

    private void Start() {
        _sol = GetComponent<ScriptableObjectLoader>();

        this.damage = _sol.Damage;
    }
}
