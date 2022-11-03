using UnityEngine;

namespace Gamespace.Core
{
    public class DotsLookSelectionWorkerCalculator : ILookSelectionWorker
    {
        public float Calculate(Vector3 vector1, Vector3 vector2)
        {
            return Vector3.Dot(vector1.normalized, vector2.normalized);
        }
    }
}