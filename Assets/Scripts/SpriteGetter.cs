using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEditor;

public class SpriteGetter : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer Sprite;
    [HideInInspector] public Animator Animator;
    private ScriptableObjectLoader _sol;
    void Start()
    {
        this._sol = GetComponent<ScriptableObjectLoader>();
        this.Sprite = GetComponent<SpriteRenderer>();
        this.Animator = GetComponent<Animator>();

        Sprite.sprite = _sol.Sprite;
        Animator.runtimeAnimatorController = _sol.AnimatorController;
    }

    void Update()
    {
        
    }
}
