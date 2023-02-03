using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(fileName = "Entity", menuName = "New Entity", order = 2)]
public class EntityScriptableObject : ScriptableObject
{
    [Header("Behaviour Parameters")]
    [Range(0.0f, 15.0f)] public float Health;
    [Range(0.0f, 15.0f)] public float Damage;
    [Range(0.0f, 15.0f)] public float Speed;
    [Range(0.0f, 5.0f)] public int AIPathRadius;
    [Range(0, 20)] public int Score;
    [SerializeField] public bool IsShootableType;


    [Header("Looks")]
    [SerializeField] public Sprite Sprite;
    [SerializeField] public RuntimeAnimatorController AnimatorController;
    
}
