using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    [SerializeField] private InputActionReference jump;
    Vector2 movement = new Vector2();
    public Rigidbody2D rb;
    bool isGrounded;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        jump.action.performed += OnJump;

    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("We jump1.");
        if (isGrounded)
        {
            isGrounded = false;
            movement.y = context.ReadValue<float>();
        }
    }

    private void Update()
    {
        Vector2 position = transform.position;
        position.x += movement.x * Time.deltaTime * speed;
        position.y += movement.y * Time.deltaTime * jumpHeight;
        transform.position = position;

    }

    public void GetPlayerMovement(InputAction.CallbackContext context)
    {
        movement.x = context.ReadValue<float>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            movement.y = 0;
        }
    }
    public void GetPlayerDash(InputAction.CallbackContext context)
    {
        
    }
}