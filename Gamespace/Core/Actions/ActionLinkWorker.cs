using System;
using System.Collections.Generic;
using Gamespace.Core.ObjectMode;
using Gamespace.Core.ObjectMode.Selection;
using Gamespace.Core.Player;
using Gamespace.UI;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Actions
{
    public class ActionLinkWorker : IInitializable, ITickable, ILateDisposable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ActionSettings _settings;
        [Inject] private IActionTypeMatching _actionTypeMatching;
        [Inject] private IObjectSelectionWorker _selectionWorker;
        [Inject] private ObjectDistanceWorker _objectDistanceWorker;
        [Inject] private IObjectSelectionRaycastWorker _raycastWorker;
        [Inject] private ActionLinkRenderer.Factory _linkRendererFactory;
        [Inject] private ActionLinkCancelInputWorker _linkCancelInputWorker;
        [Inject] private ActionLinkCommitInputWorker _linkCommitInputWorker;

        private string _relinkId;
        private string _excludeId;
        private bool _isEnabled;
        private int _index = -1;
        private Vector3 _linkEndPosition;
        private ActionLinkRenderer _linkRenderer;
        private IActionBehaviour _actionBehaviour;
        private List<IPlaceableObject> _inDistancePlaceables;
        
        private void Link()
        {
            if (_actionBehaviour is null)
                return;
            
            if (!_isEnabled)
                return;
            
            if (_index < 0)
                return;
            
            if (_inDistancePlaceables[_index].id == _excludeId)
                return;

            var acceptingTypeCount = _actionBehaviour.GetAcceptingTypes().Length;
            var acceptingTypes = _actionBehaviour.GetAcceptingTypes();
            var behaviors = new List<IActionBehaviour>();

            for (int i = 0; i < acceptingTypeCount; i++)
            {
                var matchingBehaviours = _actionTypeMatching.GetMatchingType(_inDistancePlaceables[_index].actionBehaviours, acceptingTypes[i]);

                for (int j = 0; j < matchingBehaviours.Length; j++)
                    behaviors.Add(matchingBehaviours[j]);
            }
            
            
            for (int i = 0; i < _inDistancePlaceables.Count; i++)
                _inDistancePlaceables[i].linkMaterialSwapper.SetActive(false);
            
            if (behaviors.Count <= 0)
                return;

            _isEnabled = false;
            _settings.linkIndicator.SetActive(false);
            _settings.linkCancelIndicator.SetActive(true);

            var wheelActions = new CircleWheelAction[behaviors.Count];

            for (int i = 0; i < behaviors.Count; i++)
            {
                wheelActions[i] = behaviors[i].GetWheelAction();
                wheelActions[i].action = behaviors[i].LinkWith;
            }
            
            _signalBus.AbstractFire(new CircleWheelOpenSignal(() =>
            {
                _isEnabled = true;
                _settings.linkIndicator.SetActive(true);
                _signalBus.AbstractFire(new PlayerUnlockSignal("Action Linking Wheel"));
            }, wheelActions));
            
            _signalBus.AbstractFire(new PlayerLockSignal("Action Linking Wheel"));
        }
        private void LinkCancel()
        {
            if (!_isEnabled)
                return;
            
            _actionBehaviour.CancelLinkAction(_relinkId);
            _isEnabled = false;
            _actionBehaviour = null;
            _settings.linkIndicator.SetActive(false);
            _linkRenderer.gameObject.SetActive(false);
            _settings.linkCancelIndicator.SetActive(false);
            _signalBus.AbstractFire(new ObjectSelectionEnableSignal("Action Management"));
            _signalBus.AbstractFire(new ObjectSelectionEnableSignal("Object Properties Wheel"));
        }
        public void Initialize()
        {
            _linkCommitInputWorker.Initialize(Link);
            _linkCancelInputWorker.Initialize(LinkCancel);
        }
        public void LateDispose()
        {
            _linkCommitInputWorker.Dispose();
            _linkCancelInputWorker.Dispose();
        }
        public void OnActionLinkFired(ActionLinkSignal signal)
        {
            if (_actionBehaviour != null)
            {
                _settings.linkCancelIndicator.SetActive(false);
                
                _actionBehaviour.AssignNextAction(_linkRenderer, signal.behaviour);
                _linkRenderer = null;
                _signalBus.AbstractFire(new ObjectSelectionEnableSignal("Action Management"));
                _signalBus.AbstractFire(new ObjectSelectionEnableSignal("Object Properties Wheel"));
                _signalBus.AbstractFire(new PlayerUnlockSignal("Action Linking Wheel"));
                
                _actionBehaviour = null;
                return;
            }

            _relinkId = signal.relinkId;
            _signalBus.AbstractFire(new ObjectSelectionDisableSignal("Action Management"));
            _linkRenderer = signal.linkRenderer ? signal.linkRenderer : _linkRendererFactory.Create(_settings.linkRenderer);
            _linkRenderer.gameObject.SetActive(false);
            _isEnabled = false;

            _excludeId = signal.excludeId;
            _actionBehaviour = signal.behaviour;
            _linkRenderer.gameObject.SetActive(true);
            _settings.linkCancelIndicator.SetActive(true);

            _isEnabled = true;
        }
        public void Tick()
        {
            if (_actionBehaviour is null)
                return;
            
            if (!_isEnabled)
                return;
            
            _inDistancePlaceables = _objectDistanceWorker.GetInDistanceObjects(24f);
            _index = _selectionWorker.Select(_inDistancePlaceables, _raycastWorker.Cast());
            _linkEndPosition = _index < 0 || _inDistancePlaceables[_index].id == _excludeId ? _settings.camera.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 4f)) : _inDistancePlaceables[_index].center;

            _settings.linkIndicator.SetActive(_index >= 0 && _inDistancePlaceables[_index].id != _excludeId);
            
            for (int i = 0; i < _inDistancePlaceables.Count; i++)
            {
                if (_inDistancePlaceables[i].id == _excludeId)
                    continue;
                
                _linkRenderer.SetPosition(_actionBehaviour.position, _linkEndPosition);
                _inDistancePlaceables[i].linkMaterialSwapper.SetActive(_index == i);
            }
        }
    }
}