using Zenject;
using UnityEngine;
using Gamespace.Core.ObjectMode.Placing;
using Gamespace.Core.ObjectMode.PlaceableSurface;
using Gamespace.Core.ObjectMode.Selection;

namespace Gamespace.Core.ObjectMode
{
    public class ObjectModeInstaller : MonoInstaller<ObjectModeInstaller> 
    {
        [SerializeField] private ObjectModeSettings _objectModeSettings;

        public override void InstallBindings()
        {
            Container.Bind<ObjectModeIndicatorWorker>().AsSingle();
            Container.BindInterfacesAndSelfTo<ObjectProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<ObjectDistanceWorker>().AsSingle();
            Container.Bind<ObjectDistanceBiasWorker>().AsSingle();
            
            Container.Bind<ObjectModeSettings>().FromInstance(_objectModeSettings).AsSingle();
            
            PlaceableSurfaceInstaller.Install(Container);
            ObjectModeSignalInstaller.Install(Container);
        }
    }
}