using UnityEngine;
using TMPro;

public class SlotItemCharValueController : MonoBehaviour, ISlotItemValueController
{
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private char[] _availableValues;

    public void GenerateRandomValue()
    {
        int randomValueIdex = Random.Range(0, _availableValues.Length);
        SetValue(_availableValues[randomValueIdex]);
    }

    private void SetValue(char value)
    {
        _valueText.text = value.ToString();
    }
}