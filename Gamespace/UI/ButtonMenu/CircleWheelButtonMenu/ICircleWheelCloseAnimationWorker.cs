using System;

namespace Gamespace.UI
{
    public interface ICircleWheelCloseAnimationWorker
    {
        bool isClosed { get; }
        void Initialize(Action closeAction);
        void Animate();
        void Cancel();
    }
}