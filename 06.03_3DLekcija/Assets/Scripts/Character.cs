using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health = 100;
    public string characterName;
    public Weapon weapon;

    public virtual int Attack()
    {
        return 10; 
    }

    
    public virtual void GetHit(int damage)
    {
        health -= damage;
        if (health <= 0) Die();
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




