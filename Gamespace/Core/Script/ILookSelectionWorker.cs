using UnityEngine;

namespace Gamespace.Core
{
    public interface ILookSelectionWorker
    {
        float Calculate(Vector3 vector1, Vector3 vector2);
    }
}