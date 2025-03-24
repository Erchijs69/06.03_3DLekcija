using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy
{
    public override int Attack()
    {
        return 12; // Archer has a bow attack
    }

    public override void Die()
    {
        base.Die();
        // After dying, the next enemy will be spawned by GameManager
    }
}

