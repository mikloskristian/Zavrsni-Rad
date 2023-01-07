using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingUnit : IFightable
{
    public void Attack(ShootingBehaviour SB)
    {
        SB.enabled = true;
    }
}
