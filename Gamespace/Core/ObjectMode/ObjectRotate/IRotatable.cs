using UnityEngine;

namespace Gamespace.Core
{
    public interface IRotatable
    {
        Quaternion rotateValue { get; }
        void Rotate(Quaternion rotation);
    }
}