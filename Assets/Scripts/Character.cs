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
<<<<<<< Updated upstream
    [SerializeField] private TextMeshProUGUI snotCounter;
=======

    [Header("Raycast Configuration")]
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float rayDistance;

>>>>>>> Stashed changes
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
        Debug.DrawRay(transform.position, Vector2.down* rayDistance, Color.red);

        rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);

        if (raycastGround)
        {
            animator.SetBool("Move", moveInput != 0);
            animator.SetBool("Jump", false);
            timeInAir = 0;
        }
        else
        {
            animator.SetBool("Jump",true);
            animator.SetBool("Move", false);

            if (timeInAir > 0.1f)
            {
                animator.SetBool("Jump", false);
                animator.SetBool("Land", true);
            }
        }

        if (moveInput != 0 )
        {
            spriteRenderer.flipX = moveInput < 0;
        }
<<<<<<< Updated upstream
        if (feet.landing == true)
        {
            animator.SetTrigger("FloorCollision");
            feet.landing = false;
            onAir = false;
        }
=======

>>>>>>> Stashed changes

    }


    private void OnMove (InputValue value)
    {
        moveInput = value.Get<float>();
    }

    private void OnJump(InputValue input)
<<<<<<< Updated upstream
    {
        if (onAir == false)
        {
            animator.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onAir = true;
        }
        else if (onAir == true)
        {
            print("No puedes saltar");
        }

=======
    {   
        RaycastHit2D raycastGround = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayerMask);
        if (raycastGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            timeInAir += Time.deltaTime;
        }
>>>>>>> Stashed changes
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snot"))
        {
            snots.Add(1);
            snotCounter.text = "" + snots.Count;
        }
    }


}
