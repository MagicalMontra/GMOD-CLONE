using Gamespace.Core.ObjectMode;
using UnityEngine;

namespace Gamespace.Core.ParticleObject
{
    public class ParticleSwapper : PlacingMaterialSwapper
    {
        [SerializeField] private ParticleSystem _particle;
        
#if UNITY_EDITOR
        public void SetEditorParticle(ParticleSystem particle)
        {
            _particle = particle;
            var main = _particle.main;
            main.playOnAwake = false;
        }
#endif
        public override void SetActive(bool enabled)
        {
            base.SetActive(enabled);

            if (_particle is null)
                return;
            
            if (enabled)
            {
                if (!_particle.isPlaying)
                {
                    _particle.Simulate(0, true, true);
                    _particle.Play();
                }
            }
            else
            {
                if (_particle.isPlaying)
                    _particle.Stop();
            }
        }
        public override void SetOriginalMaterial()
        {
            base.SetOriginalMaterial();
            
            if (_particle is null)
                return;

            _particle.Simulate(0, true, true);
        }
    }
}

