using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void PlayerInput()
    {
        movement = inputActions.Player.MoveLeftPaddle.ReadValue<Vector2>();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + 5f * Time.fixedDeltaTime * movement);
    }
}