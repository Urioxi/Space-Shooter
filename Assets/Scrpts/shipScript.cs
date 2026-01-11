using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
        moveInput = GetMoveInput();
        Move();
    }

    private Vector2 GetMoveInput()
    {
        Vector2 input = Vector2.zero;
        
        if (Keyboard.current.wKey.isPressed) input.y += 1;
        if (Keyboard.current.sKey.isPressed) input.y -= 1;
        if (Keyboard.current.dKey.isPressed) input.x += 1;
        if (Keyboard.current.aKey.isPressed) input.x -= 1;
        
        return input;
    }

    private void Move() => rb.linearVelocity = moveInput.normalized * moveSpeed;
}