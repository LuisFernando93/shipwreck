using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Interact Channel", fileName = "New Interact Channel")]
public class InteractEventChannel : ScriptableObject
{
    // Este é o evento. Ele pode carregar um GameObject (o objeto interagido).
    public UnityAction<GameObject> OnEventRaised;

    // Este é o método que o "Anunciante" (Jogador) chama para gritar.
    public void RaiseEvent(GameObject interactedObject)
    {
        // O "?" verifica se há alguém ouvindo. Se houver, chama todos.
        OnEventRaised?.Invoke(interactedObject);
    }
}