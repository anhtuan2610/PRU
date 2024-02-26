using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    // Add start 2024/02/25 sondv
    [SerializeField] FloatingHealthBar healthBar;
    // Add end 2024/02/25 sondv

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        // Add start 2024/02/25 sondv
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        // Add start 2024/02/25 sondv
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        healthBar.UpdateHealthBar(currentHealth, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            Debug.Log("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                Debug.Log("die");
                //Player
                if (GetComponent<PlayerWork>() != null)
                {
                    GetComponent<PlayerWork>().enabled = false;
                }

                //Enemy
                if (GetComponentInParent<EnemyPatrol>() != null)
                {
                    GetComponent<LootBag>().InstantiateLoot(transform.position);
                    Debug.Log("enemypatrol");
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                    Destroy(gameObject);
                }

                if (GetComponent<Enemy1>() != null)
                {
                    GetComponent<LootBag>().InstantiateLoot(transform.position);
                    Debug.Log("enemy1");
                    GetComponent<Enemy1>().enabled = false;
                    Destroy(gameObject);
                }


                dead = true;
            }
        }
    }
}
