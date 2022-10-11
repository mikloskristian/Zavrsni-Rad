using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyGetter : healathDamageScript
{
    [SerializeField] enemyScriptableObject[] eSO;
    [SerializeField] public bool skullLogic;
    SpriteRenderer sr;
    float enemyHealth;
    float enemyDamage;
    AIPath p;


    //ovdje su mi getteri i setteri 

    void Start()
    {
        int rnd = Random.Range(0, eSO.Length);

        sr = GetComponent<SpriteRenderer>();
        p = GetComponent<AIPath>();

        Sprite sprite = eSO[rnd].getSprite();
        float newSpeed = eSO[rnd].getEnemySpeed();
        float radius = eSO[rnd].getAIPathRadius();
        enemyHealth = eSO[rnd].getEnemyHealth();
        enemyDamage = eSO[rnd].getEnemyDamage();


        sr.sprite = sprite;
        p.maxSpeed = newSpeed;
        p.endReachedDistance = radius;


        if (rnd == 2){
            skullLogic = true;
        }

    }

    public override float health {
        get{return enemyHealth;}
        set{enemyHealth = value;}
    }
    public override float damage {
        get{return enemyDamage;}
        set{enemyDamage = value;}
    }

    void Update()
    {
        if(p.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        else if (p.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }
}
