using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Character
{
    public override int Attack()
    {
        return 20; 
    }

    public override void Die()
    {
        base.Die();
        GameManager.Instance.CreateNewEnemy();
    }
}
