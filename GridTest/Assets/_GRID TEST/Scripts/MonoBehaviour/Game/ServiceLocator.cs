using UnityEngine;

//Я бы использовал вместо этого Zenject, но по правилам этого делать нельзя

public class ServiceLocator : MonoBehaviour
{
    #region Singleton
    private static ServiceLocator _instance;
    public static ServiceLocator Instance
    {
        get
        {
            if(_instance == null) _instance = FindObjectOfType<ServiceLocator>();
            return _instance;
        }
    }
    #endregion

    [SerializeField] private DebugMessages _debugMessages;

    public DebugMessages DebugMessages => _debugMessages;
}
