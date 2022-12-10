using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy Type", order = 1)]
public class enemyScriptableObject : ScriptableObject
{

    [SerializeField] Sprite sprite;
    [SerializeField] float enemySpeed;
    [SerializeField] float enemyHealth;
    [SerializeField] float enemyDamage;
    [SerializeField] bool isShooting;
    [SerializeField] float aiPathRadius;
    [SerializeField] int enemyScore;

    public Sprite getSprite(){
        return sprite;
    }
    public float getEnemySpeed(){
        return enemySpeed;
    }
    public bool getIsShooting() { 
        return isShooting; 
    }
    public float getAIPathRadius(){
        return aiPathRadius;
    }
    public float getEnemyHealth(){
        return enemyHealth;
    }
    public float getEnemyDamage(){
        return enemyDamage;
    }
    public int getEnemyScore(){
        return enemyScore;
    }
}
