namespace Gamespace.Core.ObjectMode.Elevation
{
    public interface IElevatable
    {
        float elevateValue { get; }
        void Elevate(float value);
    }
}