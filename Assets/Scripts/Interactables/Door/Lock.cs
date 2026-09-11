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
        locked = false;
    }

    public LockType GetLockType()
    {
        return lockType;
    }
}
