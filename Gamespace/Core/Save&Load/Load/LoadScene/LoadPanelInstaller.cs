using UnityEngine;
using Zenject;
namespace Gamespace.Load
{
    public class LoadPanelInstaller : MonoInstaller<LoadPanelInstaller>
    {
         [SerializeField] private LoadSetting _loadSettings;
         public GameObject panelPrefab;
         public override void InstallBindings()
         {
            Container.BindInterfacesAndSelfTo<LoadWorker>().AsSingle();
            Container.Bind<LoadSetting>().FromInstance(_loadSettings).AsSingle();
            Container.BindFactory<LoadPanelController, LoadPanelController.Factory>().FromComponentInNewPrefab(panelPrefab);;
         }

    }
}

