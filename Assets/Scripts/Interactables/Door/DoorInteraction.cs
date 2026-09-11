using UnityEngine;

public class DoorInteraction : InteractableObj
{
    private Lock doorLock;

    private void Awake()
    {
        doorLock = GetComponent<Lock>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        canInteract = true;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact(Player player)
    {
        if (canInteract)
        {
            if (doorLock == null) //porta sem tranca
            {
                Open();
            } else //porta com tranca
            {
                if(doorLock.IsLocked()) //porta trancada
                {
                    if (doorLock.GetLockType() == LockType.SmallKey)
                    {
                        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
                        if (inventory.nKeys > 0)
                        {
                            inventory.UseKey();
                            doorLock.Unlock();
                            Open();
                        }
                        else
                        {
                            Debug.Log("Você nao possui uma chave");
                        }
                    }
                } else //porta destrancada
                {
                    Open();
                }
            }
            
        }
    }

    private void Open()
    {
        gameObject.SetActive(false);
    }
}
