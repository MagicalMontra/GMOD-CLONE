namespace Gamespace.Core.ObjectMode.Rotation
{
    public interface IRotateAxisIndicator
    {
        void Initialize();
        void SetAxis(int index);
        void SetAngle(int angle);
    }
}