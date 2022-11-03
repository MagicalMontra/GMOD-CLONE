using System;
using UnityEngine;
using Zenject;

namespace Gamespace.UI.Gauge
{
    public interface IGaugeUI
    {
        float value { get; set; }
        Type type { get; }
        void Reset();
        void Despawn();

        public class Factory : PlaceholderFactory<GameObject, Transform, IGaugeUI>
        {

        }
    }
}
