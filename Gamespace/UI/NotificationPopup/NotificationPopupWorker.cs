using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Gamespace.Localization;
using Zenject;

namespace Gamespace.UI
{
    public class NotificationPopupWorker
    {
        [Inject] private TranslatorFacade _translator;
        [Inject] private NotificationPopup.Pool _pool; 
        [Inject] private NotificationSettings _settings;

        private NotificationPopup _current;
        
        public void OnNotificationRequest(NotificationRequestSignal signal)
        {
            if (ReferenceEquals(_current, null)) 
                _current = _pool.Spawn();
            
            _translator.Translate(_settings.clusterTag, signal.titleKey, (titleValue) =>
            {
                _translator.Translate(_settings.clusterTag, signal.contextKey, (contextValue) =>
                    {
                        _translator.Translate(_settings.clusterTag, signal.dismissKey, (dismissValue) =>
                        {
                            _current.Push(titleValue, contextValue, dismissValue, () =>
                            {
                                Despawn();
                                signal.closeAction?.Invoke();
                            });
                        });
                    });
            });
        }
        private void Despawn()
        {
            if (!ReferenceEquals(_current, null))
            {
                _pool.Despawn(_current);
                _current = null;
            }
        }
    }
}