using System;

namespace Gamespace.UI
{
    public class NotificationRequestSignal
    {
        public string titleKey => _titleKey;
        public string contextKey => _contextKey;
        public string dismissKey => _dismissKey;
        public Action closeAction => _closeAction;
        
        private string _titleKey;
        private string _contextKey;
        private string _dismissKey;
        private Action _closeAction;

        public NotificationRequestSignal(string titleKey, string contextKey, string dismissKey, Action closeAction = null)
        {
            _titleKey = titleKey;
            _contextKey = contextKey;
            _dismissKey = dismissKey;
            _closeAction = closeAction;
        }
    }
}