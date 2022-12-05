using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingUnit : IFightable
{
    public void Attack(float damage, ref float health, CircleCollider2D cc)
    {
        cc.enabled = true;
    }
}
