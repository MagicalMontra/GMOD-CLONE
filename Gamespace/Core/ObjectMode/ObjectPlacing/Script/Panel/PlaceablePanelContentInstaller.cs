using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceablePanelContentInstaller : Installer<PlaceablePanelContentInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlaceableCategoryPanel>().AsSingle();
            Container.Bind<PlaceableObjectUIButtonPool>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlaceableObjectPanelOpenInputWorker>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlaceableObjectPanelCloseInputWorker>().AsSingle();
            Container.BindFactory<PlaceableObjectUIButton, Transform, PlaceableObjectUIButton, PlaceableObjectUIButton.Factory>().FromFactory<PlaceableObjectUIButtonFactory>();
        }
    }
}