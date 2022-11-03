using Zenject;

namespace Gamespace.Localization
{
    public class WordWrapInstaller : Installer<WordWrapInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<WordWrapController>().AsSingle();
            Container.Bind<BoxWidthCalculator>().AsSingle();
            Container.Bind<ITagParser>().To<HtmlTagParser>().AsSingle();
            Container.Bind<TagStringParser>().AsSingle();
            Container.Bind<IDictionary>().To<LexitronDictionary>().AsSingle();
            Container.Bind<Trie>().AsSingle();
            Container.Bind<LongParseTree>().AsSingle();
            Container.BindFactory<Language, ITokenizer, ITokenizer.Factory>().FromFactory<LexitronTokenizerFactory>();
            Container.BindFactory<Language, ITokenizer, DefaultTokenizer.Factory>().FromFactory<DefaultTokenizerFactory>();
            Container.BindFactory<ITokenizer, Language, IWordWrapWorker, IWordWrapWorker.Factory>().FromFactory<ThaiWordWrapWorkerFactory>();
            Container.BindFactory<ITokenizer, Language, IWordWrapWorker, DefaultWordWrapWorker.Factory>().FromFactory<DefaultWordWrapWorkerFactory>();

            Container.DeclareSignal<WordWrapRequestSignal>();

            Container.BindSignal<LanguageChangeResponseSignal>().ToMethod<WordWrapController>(getter => getter.OnLanguageChangeResponse).FromResolve();
            Container.BindSignal<WordWrapRequestSignal>().ToMethod<WordWrapController>(getter => getter.OnWordWrapRequest).FromResolve();
        }
    }
}