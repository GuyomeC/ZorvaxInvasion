using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Stat")]
    [SerializeField] float speed;
    private float lastPlayerDetectTime;
    public float playerDetectRate = 0.2f;
    public float chaseRange;

    [Header("Attack")]
    [SerializeField] float attackRange;
    [SerializeField] int damage;
    [SerializeField] float attackRate;
    private float lastAttackTime;

    [Header("Component")]
    Rigidbody2D rb;
    private HeroEntity targetPlayer;
    Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
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
            animator.SetTrigger("attack");
        }
    }
}
