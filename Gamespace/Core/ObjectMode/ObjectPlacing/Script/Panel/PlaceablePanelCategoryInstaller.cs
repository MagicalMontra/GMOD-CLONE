using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceablePanelCategoryInstaller : Installer<PlaceablePanelCategoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PanelCategorySelector>().AsSingle();
            Container.Bind<PlaceableCategorySelectInputWorker>().AsSingle();
            Container.BindFactory<Object, Transform, PlaceableCategoryUIButton, PlaceableCategoryUIButton.Factory>().FromFactory<PlacableObjectCategoryIndicatorFactory>();
        }
    }
}