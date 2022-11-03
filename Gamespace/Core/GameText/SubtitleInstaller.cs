using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class SubtitleInstaller : MonoInstaller<SubtitleInstaller>
{
     [SerializeField] private SubtitleSetting _subtitleSettings;

     public override void InstallBindings()
     {
         Container.BindInterfacesAndSelfTo<SubtitleWorker>().AsSingle();
         Container.Bind<SubtitleSetting>().FromInstance(_subtitleSettings).AsSingle();

         Container.DeclareSignal<ShowSubtitleSignal>();
         Container.BindSignal<ShowSubtitleSignal>().ToMethod<SubtitleWorker>(SubtitleWorker=>SubtitleWorker.SetSubtitle).FromResolve();
     }

}
