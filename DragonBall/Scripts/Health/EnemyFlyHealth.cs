using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyHealth : MonoBehaviour
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
        Debug.Log("currentHealth: " + currentHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                Debug.Log("die");
                anim.SetTrigger("die");

                //Enemy
                if (GetComponentInParent<EnemyFlyPatrol>() != null)
                {
                    GetComponentInParent<EnemyFlyPatrol>().enabled = false;
                }

                if (GetComponent<EnemyFly1>() != null)
                {
                    GetComponent<EnemyFly1>().enabled = false;
                }

                dead = true;
            }
        }
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
