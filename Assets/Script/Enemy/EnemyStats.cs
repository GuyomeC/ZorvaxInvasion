using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public int damage;
    protected int currentHealth;
    public int maxHealth;

    public GameObject healthBar;
    public Image life;

    public void InitializeBar()
    {
        this currentHealth = this.currentHealth;
    }
}
