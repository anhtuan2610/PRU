using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform kamePoint;
    [SerializeField] private GameObject[] kameBalls;

    private Animator anim;
    private PlayerWork playerMovement;
    private float cooldownTimer = Mathf.Infinity; // co the thay = 1 so lon' bat ki, set cho lan dau tien ?

    private void Awake() // ham` awake duoc goi truoc tat ca ham Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerWork>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U) && cooldownTimer > attackCooldown && playerMovement.canAttack()) 
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        kameBalls[0].transform.position = kamePoint.position;
        kameBalls[0].GetComponent<Projecttile>().SetDirection(Mathf.Sign(transform.localScale.x)); // ham Sign() tra ve -1 0 1 tuy` vao` dau' cua gia tri                  
    }
}
