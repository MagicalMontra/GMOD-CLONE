using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceablePanelInstaller : MonoInstaller<PlaceablePanelInstaller>
    {
        [SerializeField] private PlaceableObjectDatabase _database;
        [SerializeField] private PlaceableObjectPanelSettings _settings;
        [SerializeField] private PlaceableObjectNameIndicatorSettings _nameIndicatorSettings;
        [SerializeField] private PlaceableCategoryIndicatorSettings _categoryIndicatorSettings;


        public override void InstallBindings()
        {
            PlaceablePanelContentInstaller.Install(Container);
            PlaceablePanelCategoryInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<PlaceableCategoryNameIndicator>().AsSingle();
            Container.Bind<PlaceableObjectNameIndicatorSettings>().FromInstance(_nameIndicatorSettings).AsSingle();

            Container.DeclareSignal<PlaceableObjectHoverRequestSignal>();
            Container.DeclareSignal<PlaceableObjectHoverCancelSignal>();

            Container.BindSignal<ICategoryPanelChangeSignal>().ToMethod<PlaceableCategoryNameIndicator>(getter => getter.OnObjectPanelPageChanged).FromResolve();
            Container.BindSignal<PlaceableObjectHoverRequestSignal>().ToMethod<PlaceableCategoryNameIndicator>(getter => getter.OnPlaceableHoverRequest).FromResolve();
            Container.BindSignal<PlaceableObjectHoverCancelSignal>().ToMethod<PlaceableCategoryNameIndicator>(getter => getter.OnPlaceableHoverCancel).FromResolve();
            
            Container.Bind<ObjectPlacingUIControls>().AsSingle();
            Container.Bind<PlaceableObjectDatabase>().FromInstance(_database).AsSingle();
            Container.Bind<PlaceableObjectPanelSettings>().FromInstance(_settings).AsSingle();
            Container.Bind<PlaceableCategoryIndicatorSettings>().FromInstance(_categoryIndicatorSettings).AsSingle();
            
            ObjectPanelSignalInstaller.Install(Container);
        }
    }
}