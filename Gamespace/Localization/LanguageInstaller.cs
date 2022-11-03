using UnityEngine;
using Zenject;

namespace Gamespace.Localization
{
    [CreateAssetMenu(menuName = "Localization/Create LanguageInstaller", fileName = "LanguageInstaller", order = 0)]
    public class LanguageInstaller : ScriptableObjectInstaller<LanguageInstaller>
    {
        [SerializeField] private LanguageSettings _settings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LanguageController>().AsSingle();
            Container.Bind<LanguageDataLoader>().AsSingle();
            Container.Bind<LanguageSettings>().FromInstance(_settings).AsSingle();
            Container.Bind<TranslatorFacade>().AsSingle();
            
            WordWrapInstaller.Install(Container);

            Container.DeclareSignal<LanguageChangeRequestSignal>();
            Container.DeclareSignal<LanguageChangeResponseSignal>();
            
            Container.DeclareSignal<LanguageRequestSignal>();
            Container.DeclareSignal<LanguageResponseSignal>();
            
            Container.DeclareSignal<TranslateRequestSignal>();
            Container.DeclareSignal<TranslateResponseSignal>();

            Container.BindSignal<LanguageChangeRequestSignal>()
                .ToMethod<LanguageController>(getter => getter.OnLanguageChangeRequest).FromResolve();
            Container.BindSignal<TranslateRequestSignal>()
                .ToMethod<LanguageController>(getter => getter.OnTranslateRequest).FromResolve();
            Container.BindSignal<TranslateResponseSignal>()
                .ToMethod<TranslatorFacade>(getter => getter.OnLanguageValueResponse).FromResolve();
            Container.BindSignal<LanguageRequestSignal>()
                .ToMethod<LanguageController>(getter => getter.OnLanguageModeRequest).FromResolve();
        }
    }
}