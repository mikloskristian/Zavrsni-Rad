using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ScriptableObjectLoader : MonoBehaviour
{
    [SerializeField] private EntityScriptableObject[] _eso;
    [HideInInspector] public float Health;
    [HideInInspector] public float Damage;
    [HideInInspector] public float Speed;
    [HideInInspector] public int AIPathRadius;
    [HideInInspector] public int Score;
    [HideInInspector] public bool IsShootableType;
    [HideInInspector] public Sprite Sprite;
    [HideInInspector] public RuntimeAnimatorController AnimatorController;

    void Awake()
    {
        int rnd = Random.Range(0, _eso.Length);
        this.Health = _eso[rnd].Health;
        this.Damage = _eso[rnd].Damage;
        this.Speed = _eso[rnd].Speed;
        this.AIPathRadius = _eso[rnd].AIPathRadius;
        this.Score = _eso[rnd].Score;
        this.IsShootableType = _eso[rnd].IsShootableType;
        this.Sprite = _eso[rnd].Sprite;
        this.AnimatorController = _eso[rnd].AnimatorController;

    }
}
