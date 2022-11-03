using System.Collections.Generic;
using System;
using UnityEngine;
using Zenject;
namespace Gamespace.Core.Actions
{
    public class SubtitleBehaviour : StringActionBehaviour
    {
        [SerializeField] private FloatActionVariable _time;
        [SerializeField] private StringActionVariable _message;
        [SerializeField] private StringActionVariable _talkerName;
        [SerializeField] private BoolActionVariable _waitForFinishes;
        
        [Inject] private SignalBus _signalBus;
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
            return new ActionVariable[] { _time, _message, _talkerName, _waitForFinishes };
        }
        public override void Perform(string value)
        {
            var msg = _message.value;

            if(!string.IsNullOrEmpty(value))
            {
                msg =value;
            }

            if(_waitForFinishes.value)
            {
                _signalBus.Fire(new ShowSubtitleSignal(_talkerName.value,msg,_time.value,() => Next(value)));
                return;
            }
            _signalBus.Fire(new ShowSubtitleSignal(_talkerName.value,msg,_time.value));
            Next(value);
        }
    }

}
