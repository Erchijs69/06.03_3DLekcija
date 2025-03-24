using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
{
    public override int Attack()
    {
        return 15; 
    }

    public override void Die()
    {
        base.Die();
        GameManager.Instance.CreateNewEnemy();
    }
}
