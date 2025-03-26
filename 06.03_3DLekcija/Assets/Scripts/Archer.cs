using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy
{
    public override int Attack()
    {
        return weapon.GetDamage();
    }

    public override void Die()
    {
        base.Die();
    }

    
}

