using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public string charName;
    private bool isShieldActive = false;  
    private int shieldDurability = 5;  
    private bool isShieldBroken = false;  

    public int ShieldDurability => shieldDurability;  
    public bool IsShieldBroken => isShieldBroken;  

    public override int Attack()
    {
        return weapon.GetDamage();
    }

    public void ActivateShield()
    {
        if (shieldDurability > 0 && !isShieldBroken) 
        {
            isShieldActive = true;
        }
    }

    public void DeactivateShield()
    {
        isShieldActive = false;
    }

    public override void GetHit(int damage)
    {
        if (isShieldActive)
        {
            
            int maxEnemyDamage = GameManager.Instance.currentEnemy.Attack();  

            
            int damageReduction = Random.Range(2, maxEnemyDamage + 1); 
            int reducedDamage = Mathf.Max(0, damage - damageReduction);  

            shieldDurability -= 1; 
            GameManager.Instance.statusText.text = "Damage reduced by: " + damageReduction.ToString();  
            
            base.GetHit(reducedDamage); 
        }
        else
        {
            base.GetHit(damage);  
        }

        if (shieldDurability <= 0 && !isShieldBroken)
        {
            DeactivateShield();  
            isShieldBroken = true;  
            GameManager.Instance.UpdateUI();  
        }
    }
}

