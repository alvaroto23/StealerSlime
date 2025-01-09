using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D feet;


    private List<int> snots = new List<int>();
    private float moveInput;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.velocity = new Vector2(moveInput * movementSpeed * Time.deltaTime, rb.velocity.y);
        animator.SetBool("Move", moveInput != 0);
        if (moveInput != 0 )
        {
            spriteRenderer.flipX = moveInput < 0;
        }
        
    }
    

    private void OnMove (InputValue value)
    {
        moveInput = value.Get<float>();
    }

    private void OnJump(InputValue input)
    {
        animator.SetTrigger("Jump");
    }

    //private void OnTriggerEnter2D(Collider collider)
    //{
        // No se como hacer que el trigger del hijo que son los pies (feet) detecten el suelo para ejecutar la transicion de jump a idle o walk
    //}
}
