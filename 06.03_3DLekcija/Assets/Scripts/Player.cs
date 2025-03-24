using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public string charName;
    private bool isShieldActive = false;  
    private int shieldDurability = 5;  

    public override int Attack()
    {
        return weapon.GetDamage();
    }

    public void ActivateShield()
    {
        if (shieldDurability > 0)
        {
            isShieldActive = true;
            Debug.Log(charName + " shield activated!");
        }
        else
        {
            Debug.Log("No shield durability left.");
        }
    }

    public void DeactivateShield()
    {
        isShieldActive = false;
        Debug.Log(charName + " shield deactivated!");
    }

    // Override GetHit to handle shield logic
    public override void GetHit(int damage)
    {
        if (isShieldActive)
        {
            int reducedDamage = Mathf.Max(0, damage - 2);  // Reduces damage if shield is active
            shieldDurability -= 1;  // Decreases shield durability
            Debug.Log(charName + " blocked damage with shield. Reduced damage: " + reducedDamage + ". Shield durability: " + shieldDurability);
            base.GetHit(reducedDamage); // Call base class GetHit with reduced damage
        }
        else
        {
            base.GetHit(damage);  // No shield, take full damage
        }

        if (shieldDurability <= 0)
        {
            DeactivateShield();  // Deactivate shield when durability is exhausted
        }
    }
}



