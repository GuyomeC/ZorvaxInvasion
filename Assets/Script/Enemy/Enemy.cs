using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyStats
{
    [SerializeField] private ennemiPatrol partol;

    public GameObject cores;

    [Header("Attack")]
    [SerializeField] public float attackRange;
    [SerializeField] float attackRate;
    public Transform attackPoint;
    public LayerMask playerLayerMask;
    [SerializeField] public Transform checkPlayer;
    public bool playerIsNear = false;
    public bool IsAlive = true;

    [Header("Component")]
    Animator animator;

    public static Enemy instance;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CameraTriggerTarget")
        {
            playerIsNear = true;
            animator.SetTrigger("attack");
            partol.speed = 0f;
            partol.isAttacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "CameraTriggerTarget")
        {
            playerIsNear = false;
            animator.SetTrigger("run");
            partol.speed = 2f;
            partol.isAttacking = false;
        }
    }

    private void VerifPlayer()
    {
        Collider2D[] player = Physics2D.OverlapCircleAll(checkPlayer.position, 0.5f, playerLayerMask);
        foreach (var enemy_ in player)
        {
            enemy_.GetComponent<HeroTakeDamage>().TakeDamage(damage);
        }

    }
}
