using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Canceled) 
        {
            Debug.Log("interagir");
        } 
    }
}
