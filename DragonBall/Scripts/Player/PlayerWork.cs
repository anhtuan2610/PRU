using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWork : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f; // SerializeField giong nhu bien' public nhung khong cho nguoi ngoai truy cap vao giong private , chi cho DEV thay doi gia tri trong Unity Inspector ma van la tinh dong goi

    private float horizontal = 0;
    [SerializeField] private float jumpingPower = 4f;
    private bool isFacingRight = true;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            anim.SetFloat("jump", 1);
            anim.SetFloat("run", 0);
            //rb.AddForce(new Vector2(rb.velocity.x, jumpingPower));
        } 
        else if (Input.GetKey(KeyCode.J)) 
        {
            anim.SetFloat("punch", 1);
        }
        else
        {
            anim.SetFloat("punch", -1);
            anim.SetFloat("jump", -1);
            anim.SetFloat("run", Mathf.Abs(horizontal)); //khi nhan vat dung yen horizontal = 0 (<0.1)-> stand animation , khi nhan vat di chuyen horizontal = -1 / 1 su dung gia tri tuyet doi Abs (>0.1) -> move animation
        }

        Flip();

        
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight; // doi 2 thang trai phai true false voi nhau
            Vector3 localScale1 = transform.localScale;
            localScale1.x *= -1f;
            transform.localScale = localScale1;

        }
    }
    public bool canAttack()
    {
        return horizontal == 0;
    }
}
