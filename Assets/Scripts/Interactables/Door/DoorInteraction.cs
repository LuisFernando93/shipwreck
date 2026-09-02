using UnityEngine;

public class DoorInteraction : InteractableObj
{
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

    protected override void Interact()
    {
        if (canInteract)
        {
            gameObject.SetActive(false);
        }
    }
}
