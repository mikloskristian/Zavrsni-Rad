using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyGetter : MonoBehaviour
{
    [SerializeField] enemyScriptableObject[] eSO;
    SpriteRenderer sr;
    AIPath p;
    
    void Start()
    {
        int rnd = Random.Range(0, eSO.Length);

        sr = GetComponent<SpriteRenderer>();
        p = GetComponent<AIPath>();

        Sprite sprite = eSO[rnd].getSprite();
        float newSpeed = eSO[rnd].getEnemySpeed();

        sr.sprite = sprite;
        p.maxSpeed = newSpeed;

        if (rnd == 2){
            isFloatingSkull(rnd);
        }
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

    void isFloatingSkull(int skullNumber) {
        float radius = eSO[skullNumber].getAIPathRadius();
        p.endReachedDistance = radius;
        Debug.Log("radius");
        //InvokeRepeating(shooting, 2.0f, 2.0f);
    }
}
