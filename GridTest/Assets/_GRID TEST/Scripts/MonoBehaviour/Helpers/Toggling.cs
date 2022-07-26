using UnityEngine;

public abstract class Toggling : MonoBehaviour
{
    public bool IsOn {get; protected set;}

    private void Awake()
    {
        if(IsOn == false) OnDisabled();
    }
    
    public void TryToggleOn()
    {
        if(IsOn) return;

        IsOn = true;
        OnEnabled();
    }

    public void TryToggleOff()
    {
        if(IsOn == false) return;

        IsOn = false;
        OnDisabled();
    }

    protected abstract void OnEnabled();
    protected abstract void OnDisabled();
}
