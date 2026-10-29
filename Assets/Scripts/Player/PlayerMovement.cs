using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    //[SerializeField] private Transform orientation;
    //[SerializeField] private Transform playerObj;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float rotationSpeed = 10f;

    Vector2 _moveInput;
    Vector3 _moveDirection;

    CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.x = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        _moveDirection = forward * _moveInput.y + right * _moveInput.x;

        controller.Move(_moveDirection * moveSpeed * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        if (_moveDirection.sqrMagnitude > 0.001f)
        {
            Quaternion toRotation = Quaternion.LookRotation(_moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        /*Vector3 viewDir = transform.position - new Vector3(cameraTransform.position.x, transform.position.y, cameraTransform.position.z);
        orientation.forward = viewDir.normalized;

        if (_moveDirection != Vector2.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, new Vector3(_moveDirection.x, 0, _moveDirection.y), Time.deltaTime * rotationSpeed);
        }*/
    }
}
