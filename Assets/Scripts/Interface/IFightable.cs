using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFightable
{
    void Attack (float damage, float health, GameObject bullet);
}
