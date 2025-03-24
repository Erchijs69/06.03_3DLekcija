using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Enemy
{
    public override int Attack()
    {
        return 15; // Mage has a magical attack
    }

    public override void Die()
    {
        base.Die();
        // After dying, the next enemy will be spawned by GameManager
    }
}


