using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Character
{
    public override int Attack()
    {
        return 12; // Bultu uzbrukums
    }

    public override void Die()
    {
        base.Die();
        // Izveidot jaunu pretinieku
        GameManager.Instance.CreateNewEnemy();
    }
}
