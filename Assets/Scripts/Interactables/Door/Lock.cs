using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private LockType lockType;
    private bool locked = true;

    public bool IsLocked()
    {
        return locked;
    }

    public void Unlock()
    {
        switch (lockType)
        {
            case LockType.SmallKey:
                
                break;
        }
    }
}
