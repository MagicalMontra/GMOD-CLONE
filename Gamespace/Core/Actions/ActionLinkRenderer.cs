using UnityEngine;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class ActionLinkRenderer : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;

        public void SetPosition(Vector3 startPosition, Vector3 endPosition)
        {
            _lineRenderer.SetPosition(0, startPosition);
            _lineRenderer.SetPosition(1, endPosition);
        }
        
        public class Factory : PlaceholderFactory<Object, ActionLinkRenderer>{}
    }
}