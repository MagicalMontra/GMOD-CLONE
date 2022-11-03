using Gamespace.Core.Actions;
using Zenject;
using Gamespace.Core.Player;
using Gamespace.Core.GameStage;
using Gamespace.Core.ObjectMode.Selection;
using Gamespace.UI;

namespace Gamespace.Core.ObjectMode
{
    public class ObjectModeSignalInstaller : Installer<ObjectModeSignalInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PlaceableInitializeSignal>();
            Container.DeclareSignal<PlaceableDisposeRequestSignal>();
            Container.DeclareSignal<PlaceableDisposeResponseSignal>();
            
            Container.DeclareSignal<PlaceableObjectRequestSignal>();
            Container.DeclareSignal<PlaceableObjectReponseSignal>();

            Container.BindSignal<PlaceableObjectRequestSignal>().ToMethod<ObjectProvider>(getter => getter.OnPlaceableRequested).FromResolve();
            Container.BindSignal<PlaceableInitializeSignal>().ToMethod<ObjectProvider>(getter => getter.OnPlaceableInitialized).FromResolve();
            Container.BindSignal<PlaceableDisposeRequestSignal>().ToMethod<ObjectProvider>(getter => getter.OnPlaceableDispose).FromResolve();

            Container.BindSignal<GameStageSignal>().ToMethod<ObjectModeIndicatorWorker>(getter => getter.OnGameStageChange).FromResolve();
            Container.BindSignal<ICircleWheelOpenSignal>().ToMethod<ObjectModeIndicatorWorker>(getter => getter.OnCircleWheelOpened).FromResolve();
            Container.BindSignal<EditorInitializedSignal>().ToMethod<ObjectDistanceBiasWorker>(getter => getter.OnEditorPlayerInitialized).FromResolve();
            Container.BindSignal<IObjectSelectionEnableSignal>().ToMethod<ObjectModeIndicatorWorker>(getter => getter.OnObjectSelectionEnabled).FromResolve();
            Container.BindSignal<IObjectSelectionDisableSignal>().ToMethod<ObjectModeIndicatorWorker>(getter => getter.OnObjectSelectionDisabled).FromResolve();
        }
    }
}