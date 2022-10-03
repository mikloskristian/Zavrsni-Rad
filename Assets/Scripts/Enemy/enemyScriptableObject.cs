using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy Type", order = 1)]
public class enemyScriptableObject : ScriptableObject
{

    [SerializeField] Sprite sprite;
    //[SerializeField] Animator animator;
    [SerializeField] float enemySpeed;
    //[SerializeField] bool isShooting;
    //[SerializeField] float health;
    //[SerializeField] float damage;
    [SerializeField] float aiPathRadius;

    public Sprite getSprite(){
        return sprite;
    }
    //public float getAnimator() {}
    public float getEnemySpeed(){
        return enemySpeed;
    }

    //public bool getIsShooting() {}
    //public bool getHealth() {}
    //public bool getDamage() {}
    public float getAIPathRadius(){
        return aiPathRadius;
    }
}
