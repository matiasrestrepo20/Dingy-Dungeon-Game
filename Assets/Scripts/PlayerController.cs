using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody2D rb;
    Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Leemos la entrada del teclado WASD o flechas
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        direction = new Vector2(moveHorizontal, moveVertical).normalized;
    }

    void FixedUpdate()
    {
        // Movemos con la física para que choque bien con las paredes
        rb.linearVelocity = direction * speed;
    }
}