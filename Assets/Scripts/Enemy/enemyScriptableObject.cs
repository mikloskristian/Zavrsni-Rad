using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy Type", order = 1)]
public class enemyScriptableObject : ScriptableObject
{

    [SerializeField] Sprite sprite;
    //[SerializeField] Animator animator;
    [SerializeField] float enemySpeed;
    [SerializeField] float enemyHealth;
    [SerializeField] float enemyDamage;
    //[SerializeField] bool isShooting;
    [SerializeField] float aiPathRadius;

    public Sprite getSprite(){
        return sprite;
    }
    //public float getAnimator() {}
    public float getEnemySpeed(){
        return enemySpeed;
    }

    //public bool getIsShooting() {}
    public float getAIPathRadius(){
        return aiPathRadius;
    }
    public float getEnemyHealth(){
        return enemyHealth;
    }
    public float getEnemyDamage(){
        return enemyDamage;
    }
}
