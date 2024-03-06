using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhiThuyen : MonoBehaviour
{
    public float flySpeed = 5f; // Tốc độ bay lên
    [SerializeField] private Animator anim;
    private bool playerTouched = false;

    private void Update()
    {
        // Kiểm tra xem nhân vật đã chạm vào hay chưa
        if (playerTouched)
        {
            anim.SetTrigger("done");
            transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
        }
    }

    // Hàm được gọi khi có va chạm với một Collider khác
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu va chạm là với nhân vật
        if (collision.name == "Player")
        {
            playerTouched = true;
        }
    }
}
