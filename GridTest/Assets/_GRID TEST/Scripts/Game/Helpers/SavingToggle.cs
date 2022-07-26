using UnityEngine;

public abstract class SavingToggle
{
    private bool _isActive;
    
    private const int TRUE_VALUE = 1;
    private const int FALSE_VALUE = 0;

    protected abstract string ActiveKey {get;}
    public bool IsActive
    {
        get => PlayerPrefs.GetInt(ActiveKey, TRUE_VALUE) == TRUE_VALUE ? true : false;
        set => PlayerPrefs.SetInt(ActiveKey, value ? TRUE_VALUE : FALSE_VALUE);
    }

    public void SwitchActive()
    {
        if (IsActive) TryDisable();
        else TryEnable();
    }

    public virtual bool TryEnable()
    {
        if(IsActive) return false;

        IsActive = true;
        return true;
    }

    public virtual bool TryDisable()
    {
        if(IsActive == false) return false;

        IsActive = false;
        return true;
    }
}