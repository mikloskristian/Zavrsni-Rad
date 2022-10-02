using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyGetter : MonoBehaviour
{
    [SerializeField] enemyScriptableObject eSO;
    SpriteRenderer sr;
    AIPath p;
    
    void Start()
    {
        Sprite sprite = eSO.getSprite();
        float newSpeed = eSO.getEnemySpeed();
        sr = GetComponent<SpriteRenderer>();
        p = GetComponent<AIPath>();
        sr.sprite = sprite;
        p.maxSpeed = newSpeed;
        Debug.Log(p.maxSpeed);
    }

    void Update()
    {
        
    }
}
