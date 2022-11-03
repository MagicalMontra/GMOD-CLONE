using UnityEngine;
using Zenject;

namespace Gamespace.Core.Audio
{
    public class AudioInstaller : MonoInstaller<AudioInstaller>
    {
        [SerializeField] private AudioDatabase database;

        public override void InstallBindings()
        {
            Container.Bind<AudioProvider>().AsSingle();
            Container.Bind<AudioDatabase>().FromInstance(database).AsSingle();

            Container.DeclareSignal<AudioClipRequestSignal>();
            Container.DeclareSignal<AudioClipResponseSignal>();
            
            Container.DeclareSignal<AudioClipListRequestSignal>();
            Container.DeclareSignal<AudioClipListResponseSignal>();
            
            Container.BindSignal<AudioClipRequestSignal>().ToMethod<AudioProvider>(getter => getter.OnClipRequest).FromResolve();
            Container.BindSignal<AudioClipListRequestSignal>().ToMethod<AudioProvider>(getter => getter.OnClipListRequest).FromResolve();
        }
    }
}
