using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyStats
{
    [Header("Stat")]
    private float lastPlayerDetectTime;
    public float playerDetectRate = 0.2f;
 
    [Header("Attack")]
    [SerializeField] float attackRange;
    [SerializeField] float attackRate;
    private float lastAttackTime;
    public Transform attackPoint;
    public LayerMask playerLayerMask;

    [Header("Component")]
    Rigidbody2D rb;
    private HeroEntity targetPlayer;
    Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("attack");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("run");
        }
    }
}
