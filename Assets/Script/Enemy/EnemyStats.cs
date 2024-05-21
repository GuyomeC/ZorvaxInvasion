using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public int damage;
    public int currentHealth;
    public int maxHealth; 

    public Slider healthBar;
    private GameObject coresNouveau;
    
    public void UpdateHealthBar()
    {
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int damage, Vector3 spawnCores, Quaternion spawnButinRot)
    {
        currentHealth -= damage;
        Animator anim;
        anim = GetComponent<Animator>();
        UpdateHealthBar();
        StartCoroutine(Delay());
        
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(0.8f);

        }
        if (currentHealth <= 0)
        {
            Enemy.instance.IsAlive = false;
            coresNouveau = Instantiate(Enemy.instance.cores, spawnCores, spawnButinRot);
            Destroy(gameObject);
        }
    }
}
