using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Enemy
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


