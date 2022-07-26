using Zenject;

public class VibrationButton : ToggleUIButton
{
    [Inject] private Vibration _vibraion;

    protected override SavingToggle ControllingToggle => _vibraion;
}
    
