using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Hàm được gọi khi có va chạm với một Collider khác
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu va chạm là với phi thuyền
        if (collision.name == "SpaceShip")
        {
            // Gọi hàm để biến mất nhân vật
            DisappearPlayer();
        }
    }

    // Hàm để biến mất nhân vật
    private void DisappearPlayer()
    {
        // Ẩn nhân vật
        gameObject.SetActive(false);
        // Hoặc bạn có thể hủy đối tượng bằng cách sử dụng Destroy(gameObject);
    }
}
