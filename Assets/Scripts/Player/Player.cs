using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement { get; private set; }
    public PlayerInteract playerInteract { get; private set; }

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInteract = GetComponent<PlayerInteract>();

        if (playerMovement == null) Debug.Log("PlayerMovement nao encontrado");
        if (playerInteract == null) Debug.Log("PlayerInteract nao encontrado");
    }
}
