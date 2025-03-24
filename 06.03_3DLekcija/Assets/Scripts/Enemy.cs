using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public override int Attack()
    {
        return 12; // Default enemy attack value, can be overridden by specific enemies
    }

    // Override GetHit to handle custom enemy behavior if needed
    public override void GetHit(int damage)
    {
        base.GetHit(damage);
    }

    public override void Die()
    {
        base.Die();
        // Additional behavior when enemy dies (like spawning next enemy)
    }
}


