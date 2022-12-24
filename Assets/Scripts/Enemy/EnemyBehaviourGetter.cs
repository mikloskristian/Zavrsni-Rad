using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehaviourGetter : MonoBehaviour
{
    [HideInInspector] public AIPath Path;
    [HideInInspector] public bool IsShooting;
    private SpriteGetter _sg;
    void Start()
    {
        _sg = GetComponent<SpriteGetter>();
        Path = GetComponent<AIPath>();

        Path.maxSpeed = _sg.ESO[_sg.rnd].getSpeed();
        Path.radius = _sg.ESO[_sg.rnd].getAIPathRadius();
        IsShooting = _sg.ESO[_sg.rnd].getIsShooting();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
