using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Feet feet;


    private List<int> snots = new List<int>();
    private float moveInput;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        feet = GetComponentInChildren<Feet>();
    }

    void Update()
    {
        rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);
        animator.SetBool("Move", moveInput != 0);
        if (moveInput != 0 )
        {
            spriteRenderer.flipX = moveInput < 0;
        }
        if (feet.landing == true)
        {
            animator.SetTrigger("FloorCollision");
            feet.landing = false;
        }

    }


    private void OnMove (InputValue value)
    {
        moveInput = value.Get<float>();
    }

    private void OnJump(InputValue input)
    {
        animator.SetTrigger("Jump");
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

    }

}
