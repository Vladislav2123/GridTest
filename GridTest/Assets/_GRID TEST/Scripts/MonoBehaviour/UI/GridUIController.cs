using UnityEngine;
using TMPro;

public class GridUIController : MonoBehaviour
{
    [SerializeField] private Grid _controllingGrid;
    [SerializeField] private int _maxGenerateValue = 30;

    [SerializeField] private TMP_InputField _widthInputField;
    [SerializeField] private TMP_InputField _heightInputField;

    public void OnGenerateButton()
    {
        int width = 0;
        int height = 0;
        if(_widthInputField.text == "" || _heightInputField.text == "")
        {
            Debug.LogWarning("GridUIController.OnGenerateButton: Enter Something");
            return;
        }
        if(_widthInputField.text.IsNumber(out width) == false || _heightInputField.text.IsNumber(out height) == false)
        {
            Debug.LogWarning("GridUIController.OnGenerateButton: Enter Only Numbers");
            return;
        }

        width = Mathf.Clamp(width, 1, _maxGenerateValue);
        height = Mathf.Clamp(height, 1, _maxGenerateValue);

        _widthInputField.text = width.ToString();
        _heightInputField.text = height.ToString();

        _controllingGrid.Generate(width, height);
    }

    public void OnShuffleButton()
    {
        _controllingGrid.TryShuffle();
    }
}
