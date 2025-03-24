using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Berserker : Enemy
{
    public override int Attack()
    {
        return 20; // Berserker has a stronger attack
    }

    public override void Die()
    {
        base.Die();
        // After dying, the next enemy will be spawned by GameManager
    }
}

