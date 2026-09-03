using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEditor;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private InteractEventChannel interactChannel;
    [SerializeField] private Transform playerObj;
    [SerializeField] private float rayDistance = 2f; // Distância do "E"
    [SerializeField] private LayerMask interactableLayer; // Layer dos objetos interagíveis

    private GameObject currentTarget;

    private void Start()
    {
        if (interactChannel == null)
        {
            Debug.LogError("Interact channel not found on player");
        }
    }

    private void Update()
    {
        DetectObject();
    }

    public void InteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Canceled) 
        {
            //Debug.Log("interact");
            if (currentTarget != null)
            {
                interactChannel.RaiseEvent(currentTarget);
            }
        } 
    }

    private void DetectObject()
    {
        // Lança um raio invisível para frente
        Ray ray = new Ray(transform.position, playerObj.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
        {
            currentTarget = hit.collider.gameObject;
            // Debug.Log("interagivel");
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
        Gizmos.DrawRay(transform.position, playerObj.forward * rayDistance);
    }
}
