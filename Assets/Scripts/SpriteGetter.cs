using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SpriteGetter : MonoBehaviour, IPooledObject
{
    [HideInInspector] public SpriteRenderer Sprite;
    [HideInInspector] public Animator Animator;
    private ScriptableObjectLoader _sol;
    public void OnObjectSpawn()
    {
        this._sol = GetComponent<ScriptableObjectLoader>();
        this.Sprite = GetComponent<SpriteRenderer>();
        this.Animator = GetComponent<Animator>();

        Sprite.sprite = _sol.Sprite;
        Animator.runtimeAnimatorController = _sol.AnimatorController;
        Animator.Rebind();
    }

    void Start()
    {
        OnObjectSpawn();
    }
}
