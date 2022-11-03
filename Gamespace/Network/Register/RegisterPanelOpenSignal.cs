using System;

namespace Gamespace.Network.Register
{
    public class RegisterPanelOpenSignal : IRegisterPanelOpenSignal
    {
        public Action closeAction => _closeAction;
        private Action _closeAction;
        
        public RegisterPanelOpenSignal(Action closeAction = null)
        {
            _closeAction = closeAction;
        }
    }
}