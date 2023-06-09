using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NalaCombat : MonoBehaviour
{
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
           if (Input.GetKeyDown(KeyCode.Space))
           {
              Attack();
              nextAttackTime = Time.time + 1f / attackRate;

           }
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
           enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
    }

}

