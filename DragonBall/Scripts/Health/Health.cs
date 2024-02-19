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

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

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
                    Debug.Log("enemypatrol");
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                }

                if (GetComponent<Enemy1>() != null)
                {
                    Debug.Log("enemy1");
                    GetComponent<Enemy1>().enabled = false;
                }


                dead = true;
            }
        }
    }
}