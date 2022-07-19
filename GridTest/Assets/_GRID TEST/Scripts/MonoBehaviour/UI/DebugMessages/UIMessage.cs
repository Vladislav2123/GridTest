using UnityEngine;
using TMPro;

public class UIMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private float _lifeDuration;

    public void SetMessage(string message)
    {
        _messageText.text = message;
    }

    private void Start()
    {
        Destroy(gameObject, _lifeDuration);
    }
}
