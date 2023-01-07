using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehaviourGetter : MonoBehaviour
{
    [HideInInspector] public AIPath Path;
    [HideInInspector] public bool IsShooting;
    [SerializeField] private EntityScriptableObject[] _eso;
    void Start()
    {
        int rnd = Random.Range(0, _eso.Length);
        Path = GetComponent<AIPath>();

        this.Path.maxSpeed = _eso[rnd].getSpeed();
        this.Path.radius = _eso[rnd].getAIPathRadius();
        this.IsShooting = _eso[rnd].getIsShooting();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
