using model;
using view;
using Presenter;
using Zenject;
using Zenject.SpaceFighter;

public class ZenjectDIInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IPlayerModel>().To<PlayerModel>().AsSingle();
        Container.Bind<IPlayerView>().To<PlayerView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ICameraView>().To<CameraView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IPlayerPresenter>().To<PlayerPresenter>().AsSingle();
        Container.Bind<PlayerInputs>().FromComponentInHierarchy().AsSingle();
    }
}