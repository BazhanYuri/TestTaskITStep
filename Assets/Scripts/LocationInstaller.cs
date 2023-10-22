using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private SpeedChangeView _speedChangeViewPrefab;

    public override void InstallBindings()
    {
        BindPlayerInput();
        BindMovementHolder();
        BindUIBuilder();
    }
    private void BindPlayerInput()
    {
        Container.BindInterfacesTo<PlayerInput>().AsSingle();
    }
    private void BindMovementHolder()
    {
        Container.BindInterfacesTo<MovementPointsHolder>().AsSingle();
    }
    private void BindUIBuilder()
    {
        Container.BindFactory<SpeedChangeView, SpeedChangeViewFactory>().FromComponentInNewPrefab(_speedChangeViewPrefab);
        Container.BindInterfacesTo<UIBuilder>().AsSingle();
    }
}
