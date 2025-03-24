using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    public string characterName;
    public Weapon weapon;

    public virtual int Attack()
    {
        return 10; // Default attack damage
    }

    // Make GetHit virtual so it can be overridden in subclasses
    public virtual void GetHit(int damage)
    {
        health -= damage;
        Debug.Log(characterName + " took " + damage + " damage. Health: " + health);
        
        if (health <= 0) 
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(characterName + " is dead.");
    }

    public void SetWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
    }
}


