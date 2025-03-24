using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public override int Attack()
    {
        return 12; // Default enemy attack damage
    }

    // Override Die to call CreateNewEnemy
    public override void Die()
    {
        base.Die();
        GameManager.Instance.CreateNewEnemy();  // Create new enemy when this one dies
    }
}

