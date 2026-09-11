using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public int nKeys { get; private set; }

    private void Awake()
    {   
        nKeys = 0;
    }

    public void AddKey()
    {
        nKeys++;
        Debug.Log("Chave adicionada. Numero atual de chaves no inventário: " + nKeys);
    }

    public void UseKey()
    {
        if (nKeys > 0)
        {
            nKeys--;
            Debug.Log("Chave utilizada. Numero atual de chaves no inventário: " + nKeys);
        } else
        {
            Debug.Log("Você nao possui uma chave");
        }
    }
        
}
