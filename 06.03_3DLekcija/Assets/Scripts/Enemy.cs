using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public override int Attack()
    {
        return 12; 
    }

    public override void GetHit(int damage)
    {
        base.GetHit(damage);
    }

    public override void Die()
    {
        base.Die();
    }
}


