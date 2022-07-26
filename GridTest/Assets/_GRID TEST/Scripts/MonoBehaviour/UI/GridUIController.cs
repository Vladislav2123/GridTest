using UnityEngine;
using TMPro;
using Zenject;

public class GridUIController : MonoBehaviour
{
    [SerializeField] private int _maxGenerateValue = 30;
    [SerializeField] private TMP_InputField _widthInputField;
    [SerializeField] private TMP_InputField _heightInputField;

    [Inject] private Grid _grid;
    [Inject] private DebugMessages _debugMessages;
    [Inject] private Vibration _vibration;

    public void OnGenerateButton()
    {
        int width = 0;
        int height = 0;
        if(_widthInputField.text == "" || _heightInputField.text == "")
        {
            _debugMessages.TryShowMessage("Please, fill both fields");
            _vibration.TryPlayHeavyVibration();
            return;
        }
        if(_widthInputField.text.IsNumber(out width) == false || _heightInputField.text.IsNumber(out height) == false)
        {
            _debugMessages.TryShowMessage("Please, enter only numbers");
            _vibration.TryPlayHeavyVibration();
            return;
        }

        width = Mathf.Clamp(width, 1, _maxGenerateValue);
        height = Mathf.Clamp(height, 1, _maxGenerateValue);

        _widthInputField.text = width.ToString();
        _heightInputField.text = height.ToString();

        _grid.Generate(width, height);
    }

    public void OnShuffleButton()
    {
        _grid.TryShuffle();
    }
}
