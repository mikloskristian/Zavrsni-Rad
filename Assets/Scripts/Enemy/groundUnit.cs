using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundUnit : IFightable
{
    public void Attack(float damage, float health, GameObject bullet)
    {
        health = health - damage;
    }
}
