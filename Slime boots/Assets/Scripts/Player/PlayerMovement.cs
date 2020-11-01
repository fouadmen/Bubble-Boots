using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float Xmove = Input.GetAxisRaw("Horizontal");
        float Ymove = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(Xmove, Ymove) * speed;
    }


}
