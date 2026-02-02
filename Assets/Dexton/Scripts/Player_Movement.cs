using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(PlayerInput))]
public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D _rb;

    private Vector2 _moveAmount;
    public float moveSpeed = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.linearVelocity = _moveAmount;
        // bounce against other players
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Vector2 inputVector = ctx.ReadValue<Vector2>();
        _moveAmount = inputVector * moveSpeed;
    }
}