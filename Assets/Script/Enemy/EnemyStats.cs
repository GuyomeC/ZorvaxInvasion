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
        anim.SetTrigger("Hit");
        UpdateHealthBar();
        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1f);
            if (Enemy.instance.playerIsNear == true)
            {
                anim.SetTrigger("attack");
            } else
            {
                anim.SetTrigger("run");
            }
        }
        if (currentHealth <= 0)
        {
            Enemy.instance.IsAlive = false;
            coresNouveau = Instantiate(Enemy.instance.cores, spawnCores, spawnButinRot);
            Destroy(gameObject);
        }
    }
}
