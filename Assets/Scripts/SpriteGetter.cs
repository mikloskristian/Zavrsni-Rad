using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEditor;

public class SpriteGetter : MonoBehaviour
{
    [SerializeField] public EntityScriptableObject[] ESO;
    [HideInInspector] public SpriteRenderer Sprite;
    [HideInInspector] public Animator Animator;
    [HideInInspector] public int rnd;
    void Start()
    {
        rnd = Random.Range(0, ESO.Length);
        this.Sprite = GetComponent<SpriteRenderer>();
        this.Animator = GetComponent<Animator>();

        this.Sprite.sprite = ESO[rnd].getSprite();
        this.Animator.runtimeAnimatorController = ESO[rnd].getAnimatorController();
    }

    void Update()
    {
        
    }
}
