using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;

    public int GetDamage()
    {
        return Random.Range(minDamage, maxDamage); // Piemērs, kā tikt pie nejauša bojājuma vērtības
    }

    public abstract void ApplyEffect(Character target); // Abstrakta metode, kas jārealizē katram ieročam
}
