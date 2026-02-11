using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(PlayerInput))]
public class Player_Movement_New : MonoBehaviour
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
        //inputVector.x = inputVector.x == 0 ? 0 : Mathf.Sign(inputVector.x);
        //inputVector.y = inputVector.y == 0 ? 0 : Mathf.Sign(inputVector.y);

        _moveAmount = inputVector * moveSpeed;
    }
}