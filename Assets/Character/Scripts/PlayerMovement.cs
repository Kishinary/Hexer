using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 1f;
    Vector2 moveInput;

    public Vector2 movement;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.linearVelocity = moveInput * movespeed;
        movement = moveInput;
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (moveInput.x != 0 || moveInput.y != 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        if (context.performed)
        {
            Vector3 scale = transform.localScale;
            if (moveInput.x > 0)
            {
                // Facing right
                scale.x = Mathf.Abs(scale.x);
            }
            else if (moveInput.x < 0)
            {
                // Facing left
                scale.x = -Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }
    }
    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            Vector2 dashDirection = movement.normalized * movespeed * 1000; 
            rb.AddForce(dashDirection, ForceMode2D.Impulse);
            Debug.Log("Dashing in direction: " + dashDirection);
        }
       
    }
}