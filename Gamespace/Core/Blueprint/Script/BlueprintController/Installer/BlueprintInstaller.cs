using Gamespace.Core.Blueprint.Room;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Blueprint
{
    public class BlueprintInstaller : MonoInstaller<BlueprintInstaller>
    {
        [SerializeField] private BlurprintCameraSettings _cameraSettings;
        [SerializeField] private FloorSliderSettings _floorSliderSettings;
        [SerializeField] private RoomBuildPanelSetting _roomBuildPanelSetting;
        [SerializeField] private BlueprintHintSetting _hintSettings;
        [SerializeField] private RoomSettings _roomSettings;
        public override void InstallBindings()
        {
            RoomInstaller.Install(Container);
            BlueprintCameraMoveInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<BlueprintCameraZoomWorker>().AsSingle();
            Container.BindInterfacesAndSelfTo<BlueprintCameraZoomInputWorker>().AsSingle();
            Container.Bind<BlurprintCameraSettings>().FromInstance(_cameraSettings).AsSingle();

            Container.BindInterfacesAndSelfTo<FloorSliderWorker>().AsSingle();
            Container.Bind<FloorSliderInputWorker>().AsSingle();
            Container.Bind<FloorSliderSettings>().FromInstance(_floorSliderSettings).AsSingle();

            Container.BindInterfacesAndSelfTo<RoomBuildPanelWorker>().AsSingle();
            Container.Bind<RoomBuildPanelInputWorker>().AsSingle();
            Container.Bind<RoomBuildPanelSetting>().FromInstance(_roomBuildPanelSetting).AsSingle();

            Container.BindInterfacesAndSelfTo<BlueprintHintWorker>().AsSingle();
            Container.Bind<BlueprintHintSetting>().FromInstance(_hintSettings).AsSingle();

            Container.Bind<RoomSettings>().FromInstance(_roomSettings).AsSingle();
            Container.Bind<BlueprintInputControls>().AsSingle();
            Container.BindInterfacesAndSelfTo<BlueprintCameraOnStageChange>().AsSingle();

            Container.BindFactory<RoomButtonConsumer,RoomButtonConsumer.Factory>().FromComponentInNewPrefab(_roomBuildPanelSetting.roomButtonPrefab);
            Container.BindFactory<Object, RoomBase, RoomBase.Factory>().FromFactory<PrefabFactory<RoomBase>>();
        }
    }
}