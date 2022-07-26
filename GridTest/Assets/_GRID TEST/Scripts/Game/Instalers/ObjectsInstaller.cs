using UnityEngine;
using Zenject;

public class ObjectsInstaller : MonoInstaller
{
    [SerializeField] private Grid _grid;

    public override void InstallBindings()
    {
        Container.Bind<Grid>().FromInstance(_grid);
    }
}