using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEditor;

public class SpriteGetter : MonoBehaviour
{
    [SerializeField] private EntityScriptableObject[] _eso;
    [HideInInspector] public SpriteRenderer Sprite;
    [HideInInspector] public Animator Animator;
    [HideInInspector] public int rnd;
    void Start()
    {
        int rnd = Random.Range(0, _eso.Length);
        this.Sprite = GetComponent<SpriteRenderer>();
        this.Animator = GetComponent<Animator>();

        Sprite.sprite = _eso[rnd].getSprite();
        Animator.runtimeAnimatorController = _eso[rnd].getAnimatorController();
    }

    void Update()
    {
        
    }
}
