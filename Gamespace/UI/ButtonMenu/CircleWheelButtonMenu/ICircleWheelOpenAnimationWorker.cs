namespace Gamespace.UI
{
    public interface ICircleWheelOpenAnimationWorker
    {
        bool isOpened { get; }
        void Initialize();
        void Animate();
    }
}