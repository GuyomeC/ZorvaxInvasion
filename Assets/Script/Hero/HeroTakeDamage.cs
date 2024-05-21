using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTakeDamage : MonoBehaviour
{
    private HeroController heroHealth;
    public void TakeDamage(int damage)
    {
        heroHealth.currentHealth -= damage;
        Debug.Log("je t'ai tape");
    }
}