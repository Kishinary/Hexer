using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxspeed;
    float speedX, speedY;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        speedX = Input.GetAxis("Horizontal") * maxspeed;
        speedY = Input.GetAxis("Vertical") * maxspeed;
        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}
