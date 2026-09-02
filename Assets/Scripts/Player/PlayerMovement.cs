using Unity.Mathematics.Geometry;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    [SerializeField] private Transform orientation;
    [SerializeField] private Transform playerObj;
    [SerializeField] private Transform camera;
    [SerializeField] private InputActionReference movement; 
    [SerializeField] private float rotationSpeed = 10f;

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
        RotatePlayer();
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

    private void RotatePlayer()
    {
        Vector3 viewDir = transform.position - new Vector3(camera.position.x, transform.position.y, camera.position.z);
        orientation.forward = viewDir.normalized;

        if (_moveDirection != Vector2.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, new Vector3(_moveDirection.x, 0, _moveDirection.y), Time.deltaTime * rotationSpeed);
        }
    }
}
