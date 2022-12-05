using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundUnit : IFightable
{   
    public float currentHealth;
    public void Attack(float damage, ref float health, CircleCollider2D cc)
    {
        health = health - damage;
    }
}
