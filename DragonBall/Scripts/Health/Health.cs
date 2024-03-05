using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float startingHealth;
    [SerializeField] public float startingMP;
    public float currentHealth { get; set; }
    public float currentMP { get; set; }
    private Animator anim;
    private bool dead;
    [SerializeField]
    public HPBar hpBar;
    [SerializeField]
    public MPBar mpBar;
    // Add start 2024/02/25 sondv
    [SerializeField] FloatingHealthBar healthBar;
    // Add end 2024/02/25 sondv

    private void Start()
    {
    }

    private void Awake()
    {
        currentHealth = startingHealth;
        currentMP = startingMP;
        anim = GetComponent<Animator>();
        // Add start 2024/02/25 sondv
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        hpBar.UpdateHPBar(currentHealth, startingHealth);
        mpBar.UpdateMPBar(currentMP, startingMP);
        // Add start 2024/02/25 sondv
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - 1, 0, startingHealth);
        if(hpBar != null)
            hpBar.UpdateHPBar(currentHealth - 1, startingHealth);
        if(healthBar != null)
            healthBar.UpdateHealthBar(currentHealth - 1, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                //Player
                if (GetComponent<PlayerWork>() != null)
                {
                    GetComponent<PlayerWork>().enabled = false;
                }

                //Enemy
                if (GetComponentInParent<EnemyPatrol>() != null)
                {
                    GetComponent<LootBag>().InstantiateLoot(transform.position);
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                    Destroy(gameObject);
                }

                if (GetComponentInParent<EnemyFlyPatrol>() != null)
                {
                    GetComponentInParent<EnemyFlyPatrol>().enabled = false;
                }

                if (GetComponent<Enemy1>() != null)
                {
                    GetComponent<LootBag>().InstantiateLoot(transform.position);
                    GetComponent<Enemy1>().enabled = false;
                    Destroy(gameObject);
                }

                if (GetComponent<EnemyFly1>() != null)
                {
                    GetComponent<EnemyFly1>().enabled = false;
                }


                dead = true;
            }
        }
    }
}
