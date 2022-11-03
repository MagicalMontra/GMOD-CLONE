using UnityEngine;

namespace Gamespace.Core.ObjectMode.Rotation
{
    public interface IRotateAxisWorker
    {
        float value { get; }
        Quaternion Rotate(float value);
        Quaternion Reset();
    }
}