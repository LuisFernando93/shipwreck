using UnityEngine;

public abstract  class InteractableObj : MonoBehaviour 
{
    protected bool canInteract;

    protected abstract void Interact();

    protected virtual void Start()
    {
        int interactableLayer = LayerMask.NameToLayer("Interactable");

        // Verifica se a layer existe (NameToLayer retorna -1 se não achar)
        if (interactableLayer == -1)
        {
            Debug.LogError("A layer 'Interactable' não existe no projeto!");
            return;
        }

        // Atribui a layer ao GameObject onde este script está
        gameObject.layer = interactableLayer;

        // Se quiser aplicar a todos os filhos (útil se o collider estiver em um filho)
        foreach (Transform child in transform)
        {
            child.gameObject.layer = interactableLayer;
        }

        Debug.Log("Layer atribuida");
    }
}
