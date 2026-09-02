using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;

    [SerializeField] private float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        // Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        //orientation.forward = viewDir.normalized;
        
        //if (_moveDirection != Vector3.zero) 
        //{
        //    playerObj.forward = Vector3.Slerp(playerObj.forward, _moveDirection.forward, Time.deltaTime * rotationSpeed);
        //}
    }
}
