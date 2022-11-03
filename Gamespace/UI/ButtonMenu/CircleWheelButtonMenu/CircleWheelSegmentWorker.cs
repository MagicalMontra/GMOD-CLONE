using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    public class CircleWheelSegmentWorker
    {
        [Inject] private CircleWheelSettings _settings;
        [Inject] private WheelSegment.Pool _segmentPool;

        private readonly List<WheelSegment> _segments = new List<WheelSegment>();
        public SegmentData CreateSegment(int buttonCount, float previousRotation = 0)
        {
            var data = new SegmentData();
            _settings.desiredFill = 1f / (float)buttonCount;
            float fillRadius = _settings.desiredFill * 360f;
            float rotation = previousRotation + fillRadius / 2;
            previousRotation = rotation + fillRadius / 2;

            var separator = _segmentPool.Spawn(previousRotation, _settings.separatorSlot);
            data.seperator = separator;
            _segments.Add(separator);

            data.position = new Vector2(_settings.radius * Mathf.Cos((rotation - 90) * Mathf.Deg2Rad), - _settings.radius * Mathf.Sin((rotation - 90) * Mathf.Deg2Rad));
            data.scale = Vector3.one;
            
            if (rotation > 360)
                rotation -= 360;

            data.degree = rotation;
            data.rotation = previousRotation;
            return data;
        }
        public void DisposeSegments()
        {
            for (int i = 0; i < _segments.Count; i++)
                _segmentPool.Despawn(_segments[i]);
            
            _segments.Clear();
        }
    }
}