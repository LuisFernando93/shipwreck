using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    [SerializeField] private Transform orientation;
    [SerializeField] private InputActionReference movement; 

    Vector2 _moveDirection;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovementInput()
    {
        _moveDirection = movement.action.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {
        rb.linearVelocity = new Vector3(_moveDirection.x * moveSpeed, 0, _moveDirection.y * moveSpeed);
    }
}
