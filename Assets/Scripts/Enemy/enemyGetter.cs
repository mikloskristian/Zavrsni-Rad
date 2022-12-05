using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyGetter : MonoBehaviour
{
    public enemyScriptableObject[] eSO;
    SpriteRenderer sr;
    AIPath p;
    //enemyShooting eS;
    [HideInInspector] public int rnd;


    void Start()
    {
        rnd = Random.Range(0, eSO.Length);

        sr = GetComponent<SpriteRenderer>();
        p = GetComponent<AIPath>();
        

        Sprite sprite = eSO[rnd].getSprite();
        float newSpeed = eSO[rnd].getEnemySpeed();
        float radius = eSO[rnd].getAIPathRadius();


        sr.sprite = sprite;
        p.maxSpeed = newSpeed;
        p.endReachedDistance = radius;

    }


    void Update()
    {
        if(p.desiredVelocity.x >= 0.01f)
        {
            sr.flipX = false;
        }

        else if (p.desiredVelocity.x <= -0.01f)
        {
            sr.flipX = true;
        }
    }
}
