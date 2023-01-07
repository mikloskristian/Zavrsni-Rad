using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundUnit : IFightable
{   
    public void Attack(ShootingBehaviour SB)
    {
        SB.enabled = false;
    }
}
