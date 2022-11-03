
using Gamespace.Core.GameStage;
using Zenject;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class ObjectPanelSignalInstaller : Installer<ObjectPanelSignalInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignalWithInterfaces<CategoryPageChangeSignal>();
            Container.DeclareSignalWithInterfaces<PlaceableSelectSignal>();
            Container.DeclareSignalWithInterfaces<PlaceableObjectPanelOpenSignal>();
            Container.DeclareSignalWithInterfaces<PlaceableObjectPanelCancelSignal>();

            Container.BindSignal<ICategoryPanelChangeSignal>().ToMethod<PanelCategorySelector>(getter => getter.OnObjectPanelPageChanged).FromResolve();
            Container.BindSignal<IPlaceablePanelOpenSignal>().ToMethod<PanelCategorySelector>(getter => getter.OnPlaceablePanelOpened).FromResolve();
            Container.BindSignal<IPlaceablePanelOpenSignal>().ToMethod<PlaceableCategoryPanel>(getter => getter.OnPlaceablePanelOpened).FromResolve();
            Container.BindSignal<IPlaceablePanelCloseSignal>().ToMethod<PlaceableCategoryPanel>(getter => getter.OnPlaceablePanelCloseSignal).FromResolve();
            Container.BindSignal<ICategoryPanelChangeSignal>().ToMethod<PlaceableCategoryPanel>(getter => getter.OnObjectPanelPageChanged).FromResolve();
            Container.BindSignal<GameStageSignal>().ToMethod<PlaceableCategoryPanel>(getter => getter.OnGameStageChange).FromResolve();
            Container.BindSignal<GameStageSignal>().ToMethod<PanelCategorySelector>(getter => getter.OnGameStageChange).FromResolve();
        }
    }
}