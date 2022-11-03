using Zenject;

namespace Gamespace.Core.Audio
{
    public class AudioProvider
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private AudioDatabase _database;

        public void OnClipRequest(AudioClipRequestSignal signal)
        {
            var data = _database.Get(signal.name);
            _signalBus.Fire(new AudioClipResponseSignal(data));
        }

        public void OnClipListRequest(AudioClipListRequestSignal signal)
        {
            _signalBus.Fire(new AudioClipListResponseSignal(_database.Search(signal.searchName)));
        }
    }
}