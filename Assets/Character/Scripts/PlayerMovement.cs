using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 1f;
    Vector2 moveInput;

    Rigidbody2D rb;
    Animator animator;
    public float Enegrgy = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.linearVelocity = moveInput * movespeed;
        Dash();
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
        Vector2 DashDirection;
        Enegrgy += Time.deltaTime * 10f;
        if (Enegrgy >= 10)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (moveInput.x != 0)
                {
                    Vector2 dashDirection = moveInput.normalized * movespeed * 14;
                    DashDirection = dashDirection;
                }
                else
                {
                    Vector2 dashDirection = new Vector2(transform.localScale.x * movespeed * 3, 0);
                    DashDirection = dashDirection;
                }



                    rb.AddForce(DashDirection, ForceMode2D.Impulse);
                Debug.Log("Dashing in direction: " + DashDirection);
                Enegrgy = 0;
                animator.SetBool("Dash", true);
                

                float dashDuration = 0.2f; // Duration of the dash
                dashDuration -= Time.deltaTime;
                if (dashDuration ==0)
                {
                    animator.SetBool("Dash", false);
                }


            }
        }
    }
}