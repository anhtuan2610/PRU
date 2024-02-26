using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Kame Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform kamePoint;
    [SerializeField] private float range;
    [SerializeField] private GameObject[] kameBalls;
    [SerializeField] private GameObject[] monkeyKameBalls;

    [Header("Punch Parameters")]
    [SerializeField] private float punchDamege;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask enemyLayer;

    private Animator anim;
    private PlayerWork playerMovement;
    private Health enemyHealth;

    private float cooldownTimer = Mathf.Infinity; // co the thay = 1 so lon' bat ki, set cho lan dau tien ?

    private void Awake() // ham` awake duoc goi truoc tat ca ham Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerWork>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.J) && playerMovement.canAttack())
        {
            if (playerMovement.monkeyCheckPublic() == false) // check monkey
            {
                anim.SetFloat("punch", 1);
                if (EnemyInSight())
                {
                    Debug.Log("punch");
                }
            } else
            {
				anim.SetTrigger("monkeyPunch");
				if (EnemyInSight())
				{
					Debug.Log("monkeyPunch");
				}
			}
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        if (playerMovement.monkeyCheckPublic())
        {
            anim.SetTrigger("monkeyKame");
            cooldownTimer = 0;
            monkeyKameBalls[0].transform.position = kamePoint.position;
            monkeyKameBalls[0].GetComponent<Projecttile>().SetDirection(Mathf.Sign(transform.localScale.x)); // ham Sign() tra ve -1 0 1 tuy` vao` dau' cua gia tri  
        }
        else
        {
            anim.SetTrigger("attack");//playerKame
            cooldownTimer = 0;
            kameBalls[0].transform.position = kamePoint.position;
            kameBalls[0].GetComponent<Projecttile>().SetDirection(Mathf.Sign(transform.localScale.x)); // ham Sign() tra ve -1 0 1 tuy` vao` dau' cua gia tri                  
        }
    }

    private bool EnemyInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, // ham` BoxCast duoc su dung de kiem tra va cham voi cac collider , ket qua duoc gan cho hit
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, enemyLayer);

        if (hit.collider != null)
            enemyHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    private void OnDrawGizmos() // dung de ve~ hinh de chinh? tam danh cua enemy cho de~ hon
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamageEnemy()
    {
        if (EnemyInSight())
            enemyHealth.TakeDamage(punchDamege);
    }
}
