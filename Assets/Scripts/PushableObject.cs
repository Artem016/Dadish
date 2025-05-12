using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (!isGrounded)
        {
            Debug.LogError(0);
            //rb.velocity = new Vector2(0f, rb.velocity.y);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleEnterInteraction(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleEnterInteraction(collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        HandleExitInteraction(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HandleExitInteraction(collision.gameObject);
    }

    private void HandleEnterInteraction(GameObject other)
    {
        if (other.TryGetComponent<IReactiveInteractable>(out var reactiveInteractable))
            reactiveInteractable.EnterInteract();
    }

    private void HandleExitInteraction(GameObject other)
    {
        if (other.TryGetComponent<IReactiveInteractable>(out var reactiveInteractable))
            reactiveInteractable.ExitInteract();
    }
}
