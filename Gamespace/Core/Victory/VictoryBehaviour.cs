using System.Collections.Generic;
using System;
using Zenject;
namespace Gamespace.Core.Actions
{
    public class VictoryBehaviour : FloatActionBehaviour
    {
        public FloatActionVariable expectValue;
        
        private bool _isVictory;
        [Inject] private VictoryWorker _victoryWorker;
        public override Type[] GetAcceptingTypes()
        {
             var types = new List<Type>
            {
                typeof(IntActionBehaviour),
                typeof(VoidActionBehaviour),
                typeof(FloatActionBehaviour),
                typeof(StringActionBehaviour)
            };
            return types.ToArray();
        }
        protected override ActionVariable[] Variables()
        {
            return new ActionVariable[]{ expectValue };
        }
        public override void Perform(float value)
        {
            _isVictory = !(value < expectValue.value);
            _victoryWorker.SetUpVictoryPanel(_isVictory);
            Next();
        }
    }

}
