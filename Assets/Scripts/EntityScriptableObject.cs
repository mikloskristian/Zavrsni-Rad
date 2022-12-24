using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

[CreateAssetMenu(fileName = "Entity", menuName = "New Entity", order = 2)]
public class EntityScriptableObject : ScriptableObject
{

    [SerializeField] Sprite Sprite;
    [SerializeField] AnimatorController AnimatorController;
    [SerializeField] float Speed;
    [SerializeField] float Health;
    [SerializeField] float Damage;
    [SerializeField] bool IsShooting;
    [SerializeField] float AIPathRadius;
    [SerializeField] int Score;

    public Sprite getSprite(){
        return Sprite;
    }
    public AnimatorController getAnimatorController()
    {
        return AnimatorController;
    }
    public float getSpeed(){
        return Speed;
    }
    public float getHealth(){
        return Health;
    }
    public float getDamage(){
        return Damage;
    }
    public bool getIsShooting() { 
        return IsShooting; 
    }
    public float getAIPathRadius(){
        return AIPathRadius;
    }
    public int getEnemyScore(){
        return Score;
    }
}
