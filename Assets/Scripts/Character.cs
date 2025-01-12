using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;

    [Header("Raycast Configuration")]
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float rayDistance;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private float timeInAir;

    private float moveInput;
    private bool onAir;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
 
    }

    void Update()
    {
        RaycastHit2D raycastGround = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayerMask);
        Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);

        rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);

        if (raycastGround)
        {
            animator.SetBool("Move", moveInput != 0);
            animator.SetBool("Jump", false);
            timeInAir = 0;
        }
        else if (!raycastGround)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Move", false);
            timeInAir += Time.deltaTime;
        }
        if (moveInput != 0)
        {
            spriteRenderer.flipX = moveInput < 0;
        }
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
    }

    private void OnJump(InputValue input)
    {
        {
            RaycastHit2D raycastGround = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayerMask);
            if (raycastGround)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                timeInAir += Time.deltaTime;
            }
        }
    }
}
