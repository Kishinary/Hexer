using UnityEngine;

public class runchicken : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) // đi lên
            moveInput.y = 1;
        if (Input.GetKey(KeyCode.S)) // đi xuống
            moveInput.y = -1;
        if (Input.GetKey(KeyCode.A)) // đi trái
            moveInput.x = -1;
        if (Input.GetKey(KeyCode.D)) // đi phải
            moveInput.x = 1;

        moveInput.Normalize(); // giữ tốc độ đều khi đi chéo
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
