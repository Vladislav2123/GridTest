using UnityEngine;

public abstract class ToggleUIButton : MonoBehaviour
{
    private Toggling _uiToggle;

    protected abstract SavingToggle ControllingToggle {get;}

    private void Awake()
    {
        _uiToggle = GetComponent<Toggling>();
    }

    private void Start()
    {
        TryRefreshView();
    }

    public void OnClick()
    {
        ControllingToggle.SwitchActive();
        TryRefreshView();
    }

    private void TryRefreshView()
    {
        if(_uiToggle == null) return;

        if(ControllingToggle.IsActive) _uiToggle.TryToggleOn();
        else _uiToggle.TryToggleOff();
    }
}
