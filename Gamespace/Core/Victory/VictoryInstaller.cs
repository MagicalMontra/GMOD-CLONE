using System.Collections;
using UnityEngine;
using Zenject;
namespace Gamespace.Core.Actions
{
    public class VictoryInstaller : MonoInstaller<VictoryInstaller>
    {
        [SerializeField] private VictorySetting _victorySetting;
        public override void InstallBindings()
        {
             Container.BindInterfacesAndSelfTo<VictoryWorker>().AsSingle();
            Container.Bind<VictorySetting>().FromInstance(_victorySetting).AsSingle();
           
        }
    }   

}
