using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //public float moveSpeed = 4;
    //public float playerMove;
    private float moveSpeed = 2f;
    private float horizontal = 0; // trai phai
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        ////di chuyen
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //{
        //    playerMove = -1;
        //} else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //{ 
        //    playerMove = 1;
        //} else
        //{
        //    playerMove = 0;
        //}

        //transform.Translate(Vector3.right * moveSpeed * playerMove * Time.deltaTime);

        horizontal = Input.GetAxisRaw("Horizontal"); // A=-1 , D=1 // lay truc X 

        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        { 
            Debug.Log("here2");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            //rb.AddForce(new Vector2(rb.velocity.x, jumpingPower));
        }
        
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);// rb.velocity dai dien cho van toc cua 1 doi tuong
                                                                         // rb.velocity.y giu~ nguyen truc Y tai vi tri hien tai
                                                                         // Khi rb.velocity duoc gan gia tri moi, Rigidbody2D (rb) se xu ly viec cap nhat vi tri cua doi tuong dua tren van toc do. Dieu nay cho phep doi tuong di chuyen theo huong va toc do xac dinh.
                                                                         // Do do, mac du cac thuoc tinh chi khai bao thong tin ve van toc va toc do di chuyen, viec thay doi va ap dung gia tri van toc nay vao Rigidbody2D se lam cho doi tuong thuc su di chuyen tren man hinh.
    }

    private bool IsGrounded()
    {

        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundPlayer);
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
}
