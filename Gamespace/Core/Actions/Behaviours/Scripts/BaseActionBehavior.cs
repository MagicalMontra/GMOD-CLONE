using System;
using nanoid;
using Zenject;
using UnityEngine;
using System.Linq;
using Gamespace.UI;
using System.Reflection;
using Gamespace.Core.Player;
using System.Collections.Generic;
using Gamespace.Core.ObjectMode.Selection;

namespace Gamespace.Core.Actions
{
    public abstract class BaseActionBehavior : MonoBehaviour, IActionBehaviour
    {
        public string id => _id;
        public string objectName => _objectName;
        public Vector3 position => transform.position;
        
        protected string _objectName;
        protected SignalBus _signalBus;
        
        [SerializeField] private bool _haveProperty;
        [SerializeField] private string _wheelButtonId;
        
        private string _id;
        private string _objectId;
        private string[] _fieldNames;
        private List<ActionLinkData> _nextActions = new List<ActionLinkData>();

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            OnConstruct();
        }
        public virtual void OnConstruct()
        {
            
        }
        public void AssignNextAction(ActionLinkRenderer renderer, IActionBehaviour behaviour)
        {
            var index = _nextActions.FindIndex(b => b.linkedBehaviourId == behaviour.id);
            if (index > -1)
            {
                _nextActions[index].linkRenderer = renderer;
                _nextActions[index].linkedBehaviour = behaviour;
                _nextActions[index].linkedBehaviourId = behaviour.id;
                return;
            }

            var data = new ActionLinkData
            {
                linkRenderer = renderer, 
                linkedBehaviour = behaviour, 
                linkedBehaviourId = behaviour.id
            };

            _nextActions.Add(data);
        }
        public void CancelLinkAction(string id)
        {
            var index = _nextActions.FindIndex(b => b.linkedBehaviourId == id);
            
            if (index > -1)
                _nextActions.RemoveAt(index);
        }
        public CircleWheelAction GetWheelAction()
        {
            return new CircleWheelAction(_wheelButtonId, InitiateLink);
        }
        public virtual void OnInitialized(string objectId, string objectName)
        {
            if (string.IsNullOrEmpty(_id))
                _id = NanoId.Generate(5);
            
            _objectId = objectId;
            _objectName = objectName;
        }
        public void LinkWith()
        {
            _signalBus.AbstractFire(new ActionLinkSignal(_objectId, this));
        }
        private void InitiateLink()
        {
            var wheelActions = new List<CircleWheelAction>();
            
            wheelActions.Add(new CircleWheelAction("Link Action", () =>
            {
                _signalBus.AbstractFire(new PlayerUnlockSignal("Object Properties Wheel"));
                _signalBus.Fire(new ActionLinkSignal(_objectId, this));
            }));

            if (_nextActions.Count > 0)
            {
                var linkedActions = new List<CircleWheelAction>();

                for (int i = 0; i < _nextActions.Count; i++)
                {
                    var index = i;
                    var action = new CircleWheelAction("Link Action", $"link to {_nextActions[index].linkedBehaviour.objectName}", () =>
                    {
                        _signalBus.AbstractFire(new PlayerUnlockSignal("Object Properties Wheel"));
                        _signalBus.AbstractFire(new EditorPlayerLookAtRequestSignal(_nextActions[index].linkedBehaviour.position));
                        _signalBus.Fire(new ActionLinkSignal(_nextActions[index].linkedBehaviourId, _objectId, this, _nextActions[index].linkRenderer));
                    });
                    linkedActions.Add(action);
                }
                
                wheelActions.Add(new CircleWheelAction("Link Management", () => _signalBus.AbstractFire(new CircleWheelOpenSignal(null, linkedActions.ToArray()))));
            }

            if (_haveProperty)
                wheelActions.Add(new CircleWheelAction("Action Property", () =>
                {
                    _signalBus.AbstractFire(new ObjectSelectionEnableSignal("Object Properties Wheel"));
                    _signalBus.AbstractFire(new PlayerUnlockSignal("Object Properties Wheel"));
                    _signalBus.AbstractFire(new ActionPropertyRequestSignal(name, FieldNames(), Variables()));
                }));
            
            _signalBus.AbstractFire(new CircleWheelOpenSignal(null, wheelActions.ToArray()));
        }
        protected virtual string[] FieldNames()
        {
            return _fieldNames ??= GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(field => field.FieldType.IsSubclassOf(typeof(ActionVariable))).Select(field => field.Name).ToArray();
        }
        protected abstract ActionVariable[] Variables();
        public void Next()
        {
            for (int i = 0; i < _nextActions.Count; i++)
                _nextActions[i].linkedBehaviour.Perform();
        }
        public void Next(int value)
        {
            for (int i = 0; i < _nextActions.Count; i++)
                _nextActions[i].linkedBehaviour.Perform(value);
        }
        public void Next(float value)
        {
            for (int i = 0; i < _nextActions.Count; i++)
                _nextActions[i].linkedBehaviour.Perform(value);
        }
        public void Next(string value)
        {
            for (int i = 0; i < _nextActions.Count; i++)
                _nextActions[i].linkedBehaviour.Perform(value);
        }
        public abstract void Perform();
        public abstract void Perform(int value);
        public abstract void Perform(float value);
        public abstract void Perform(string value);
        public abstract Type[] GetAcceptingTypes();
    }
}