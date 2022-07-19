using UnityEngine;

public class DebugMessages : MonoBehaviour
{
    [SerializeField] private UIMessage _messagePrefab;
    [SerializeField] private Transform _messagesSpawnPoint;
    [SerializeField] private bool _isActive;

    public void TryShowMessage(string message)
    {
        if(_isActive == false) return;

        UIMessage newMessage = Instantiate(_messagePrefab, _messagesSpawnPoint.position, Quaternion.identity, transform);
        newMessage.SetMessage(message);
    }
}
