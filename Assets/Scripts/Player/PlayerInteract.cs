using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEditor;

public class PlayerInteract : MonoBehaviour
{
    public event Action<GameObject> OnInteract;

    [SerializeField] private float rayDistance = 2f; // Distância do "E"
    [SerializeField] private LayerMask interactableLayer; // Layer dos objetos interagíveis

    private GameObject currentTarget;
    
    private void Update()
    {
        DetectObject();
    }

    public void InteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Canceled) 
        {
            if (currentTarget != null)
            {
                OnInteract?.Invoke(currentTarget);
            }
        } 
    }

    private void DetectObject()
    {
        // Lança um raio invisível para frente
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
        {
            currentTarget = hit.collider.gameObject;
            // Aqui você poderia disparar outro evento para mostrar "Aperte E" na UI
        }
        else
        {
            currentTarget = null;
        }
    }

    // Visualização do raio no Editor (opcional)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
    }
}
