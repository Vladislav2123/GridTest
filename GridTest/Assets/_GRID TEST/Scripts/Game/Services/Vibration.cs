using UnityEngine;

public class Vibration : SavingToggle
{
    protected override string ActiveKey => "VibrationActive";

    public override bool TryEnable()
    {
        if(base.TryEnable() == false) return false;

        TryPlayLightVibration();
        return true;
    }

    public void TryPlayLightVibration()
    {
        if (IsActive == false) return;

        Debug.LogWarning("Light vibration playing");
    }
    public void TryPlayMediumVibration()
    {
        if (IsActive == false) return;

        Debug.LogWarning("Medium vibration playing");
    }
    public void TryPlayHeavyVibration()
    {
        if (IsActive == false) return;

        Debug.LogWarning("Heavy vibration playing");
    }
}
