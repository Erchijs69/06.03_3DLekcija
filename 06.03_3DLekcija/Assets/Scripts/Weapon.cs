using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;

    public int GetDamage()
    {
        return Random.Range(minDamage, maxDamage); // RandomDamage
    }

    public abstract void ApplyEffect(Character target); 
}
