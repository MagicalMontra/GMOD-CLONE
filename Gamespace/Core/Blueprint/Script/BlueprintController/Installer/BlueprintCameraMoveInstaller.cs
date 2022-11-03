using Zenject;

namespace Gamespace.Core.Blueprint
{
    public class BlueprintCameraMoveInstaller : Installer<BlueprintCameraMoveInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BlueprintCameraMoveWorker>().AsSingle();
            Container.BindInterfacesAndSelfTo<BlueprintCameraMoveInputWorker>().AsSingle();
        }
    }
}