using System;

namespace Gamespace.Network.Register
{
    public interface IRegisterPanelOpenSignal
    {
        Action closeAction { get; }
    }
}