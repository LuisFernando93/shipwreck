using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement { get; private set; }
    public PlayerInteract playerInteract { get; private set; }
    public PlayerInventory playerInventory { get; private set; }

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInteract = GetComponent<PlayerInteract>();
        playerInventory = GetComponent<PlayerInventory>();

        if (playerMovement == null) Debug.Log("PlayerMovement nao encontrado");
        if (playerInteract == null) Debug.Log("PlayerInteract nao encontrado");
        if (playerInventory == null) Debug.Log("PlayerInventory nao encontrado");
    }
}
