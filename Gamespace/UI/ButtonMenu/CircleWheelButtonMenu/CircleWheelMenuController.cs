using System;
using Zenject;
using UnityEngine;
using System.Collections.Generic;

namespace Gamespace.UI
{
    public class CircleWheelMenuController : IInitializable, ITickable, ILateDisposable
    {
        [Inject] private WheelButtonDatabase _database;
        [Inject] private CircleWheelSettings _settings;
        [Inject] private CircleMiddleWorker _middleWorker;
        [Inject] private CircleWheelPageWorker _pageWorker;
        [Inject] private CircleWheelColorWorker _colorWorker;
        [Inject] private CircleWheelButtonWorker _buttonWorker;
        [Inject] private CircleWheelSegmentWorker _segmentWorker;
        [Inject] private CircleWheelRotationWorker _rotationWorker;
        [Inject] private CircleWheelExitInputWorker _exitInputWorker;
        [Inject] private ICircleWheelOpenAnimationWorker _openAnimationWorker;
        [Inject] private ICircleWheelCloseAnimationWorker _closeAnimationWorker;
        [Inject] private CircleWheelPageChangeInputWorker _pageChangeInputWorker;
        [Inject] private CircleWheelMouseExecuteInputWorker _mouseExecuteInputWorker;
        [Inject] private CircleWheelMousePositionInputWorker _mousePositionInputWorker;
        
        private bool _isOpened;
        private bool _needUpdate;
        private Action _closeAction;
        private Vector2 _menuCenter;
        private ExtendedWheelButton _selectSegment;
        private List<ICircleWheelOpenSignal> _wheelStack = new List<ICircleWheelOpenSignal>();

        public void OnCircleWheelOpened(ICircleWheelOpenSignal signal)
        {
            _closeAnimationWorker.Cancel();
            _settings.separatorSlot.gameObject.SetActive(_settings.useSeparator);
            _pageWorker.Initialize(signal.actions);
            _closeAction = signal.closeAction;
            ConstructSegments(_pageWorker.isInitialize ? _pageWorker.currentPage : signal.actions);
            _wheelStack.Add(signal);
            
            Open();
        }
        public void CircleWheelCloseRequested(ICircleWheelCloseRequest signal)
        {
            CancelWheel();
        }
        private void ConstructSegments(CircleWheelAction[] actions)
        {
            _buttonWorker.RemoveButtons();
            _segmentWorker.DisposeSegments();
            
            var rotation = 0f;
            
            var datas = new List<WheelButtonData>();
            
            for (int i = 0; i < actions.Length; i++)
            {
                var data = _database.GetData(actions[i].id);
                if (data is null)
                    continue;

                if (!string.IsNullOrEmpty(actions[i].desc))
                    data.desc = actions[i].desc;
                
                datas.Add(data);
            }

            for (int i = 0; i < datas.Count; i++)
            {
                var segment = _segmentWorker.CreateSegment(datas.Count, rotation);
                var button = _buttonWorker.CreateButton();
                button.Initialize(segment);
                button.Setup(actions[i].action, datas[i]);
                rotation = segment.rotation;
                
                _selectSegment = button;
                var but = _selectSegment;
                _selectSegment = but;
                if (but.useCustomColor)
                    but.SetColor(but.customColor);
                else
                    but.SetColor(but.useCustomColor ? but.customColor : _settings.accentColor);
            }
        }
        private void CancelWheel()
        {
            if (!_needUpdate)
                return;

            if (_wheelStack.Count > 1)
            {
                _wheelStack.RemoveAt(_wheelStack.Count - 1);
                _closeAction = _wheelStack[_wheelStack.Count - 1].closeAction;
                ConstructSegments(_wheelStack[_wheelStack.Count - 1].actions);
                return;
            }
            
            _wheelStack.Clear();
            _closeAnimationWorker.Initialize(_closeAction);
            _closeAnimationWorker.Animate();
            _buttonWorker.RemoveButtons();
            _exitInputWorker.Dispose();
            _mouseExecuteInputWorker.Dispose();
            _mousePositionInputWorker.Dispose();
            _segmentWorker.DisposeSegments();
            _isOpened = false;
            _needUpdate = false;
        }
        private void CloseWheel()
        {
            if (!_openAnimationWorker.isOpened)
                return;
            
            _wheelStack.Clear();
            _closeAnimationWorker.Initialize(null);
            _closeAnimationWorker.Animate();
            _buttonWorker.RemoveButtons();
            _exitInputWorker.Dispose();
            _mouseExecuteInputWorker.Dispose();
            _mousePositionInputWorker.Dispose();
            _segmentWorker.DisposeSegments();
            _isOpened = false;
            _needUpdate = false;
        }
        private void Open()
        {
            _settings.background.color = _settings.backgroundColor;
            _menuCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            _isOpened = true;
            _settings.panel.transform.localScale = _settings.openAnimation == AnimationType.zoomIn ? Vector3.zero : Vector3.one * 10;
            _needUpdate = true;
            
            _mouseExecuteInputWorker.Initialize(() =>
            {
                if (!_openAnimationWorker.isOpened)
                    return;
                
                if (!_settings.cursor.isActiveAndEnabled)
                    return;

                _selectSegment.onClick.Invoke();
                CloseWheel();
            });
            
            _mousePositionInputWorker.Initialize();
            _exitInputWorker.Initialize(CancelWheel);
            _openAnimationWorker.Initialize();
            _openAnimationWorker.Animate();
        }

        private void ChangePage(int value)
        {
            if (!_isOpened)
                return;
            
            if (_mouseExecuteInputWorker.isPressed)
                return;
            
            _pageWorker.ChangePage(value);
            ConstructSegments(_pageWorker.currentPage);
        }
        public void Initialize()
        {
            _pageChangeInputWorker.Initialize(ChangePage);
        }
        public void LateDispose()
        {
            _pageChangeInputWorker.Dispose();
        }
        public void Tick()
        { 
            if (!_needUpdate)
                return;
            
            // if (_audioCoolDown > 0)
            //     _audioCoolDown -= Time.deltaTime;
            if (_openAnimationWorker.isOpened)
            {
                if (_settings.panel.transform.localScale.x >= _settings.size - .2f)
                {
                    _rotationWorker.Rotate(_menuCenter);
                    _selectSegment = _colorWorker.Handle(_menuCenter, _selectSegment);
                    _middleWorker.Handle(_selectSegment);
                }
            }
        }
    }
}