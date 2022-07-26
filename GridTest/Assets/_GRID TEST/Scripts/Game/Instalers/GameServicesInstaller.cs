using UnityEngine;
using Zenject;

public class GameServicesInstaller : MonoInstaller
{
    [SerializeField] private DebugMessages _debugMessages;

    public override void InstallBindings()
    {
        Container.Bind<DebugMessages>().FromInstance(_debugMessages);
        Container.Bind<Vibration>().FromNew().AsSingle();
    }
}