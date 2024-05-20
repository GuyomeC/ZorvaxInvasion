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

    public GameObject healthBar;
    private GameObject coresNouveau;
    
    public Image life;

    public void UpdateHealthBar(int value)
    {
        life.fillAmount = (float)value / maxHealth;
    }

    public void TakeDamage(int damage, Vector3 spawnCores, Quaternion spawnButinRot)
    {
        currentHealth -= damage;
        Animator anim;
        anim = GetComponent<Animator>();
        anim.SetTrigger("Hit");
        UpdateHealthBar(currentHealth);
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
        healthBar.SetActive(true);
        if (currentHealth <= 0)
        {
            coresNouveau = Instantiate(Enemy.instance.cores, spawnCores, spawnButinRot);
            Destroy(gameObject);
        }
    }
}
