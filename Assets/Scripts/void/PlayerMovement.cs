using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Input01 input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null;

    [SerializeField] public float MoveSpeed;
    private void Awake()
    {
        input = new Input01();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += OnMovePer;
        input.Player.Move.canceled += OnMoveCancel;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Move.performed -= OnMovePer;
        input.Player.Move.canceled -= OnMoveCancel;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * MoveSpeed;
    }

    private void OnMovePer(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMoveCancel(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
}
