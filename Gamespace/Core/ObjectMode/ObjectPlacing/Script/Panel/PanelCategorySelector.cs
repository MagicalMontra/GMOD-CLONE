using Gamespace.Core.GameStage;
using Gamespace.Localization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;
using Object = UnityEngine.Object;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PanelCategorySelector : IInitializable, IOnGameStageChange
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private PlaceableObjectDatabase _database;
        [Inject] private PlaceableCategoryIndicatorSettings _settings;
        [Inject] private PlaceableCategorySelectInputWorker _inputWorker;
        [Inject] private PlaceableCategoryUIButton.Factory _categoryUI;

        private int _pointer;
        private bool _isEnabled;
        public void Initialize()
        {
            for (int i = 0; i < _database.count; i++)
            {
                var categoryUIButton = _categoryUI.Create(_settings.categoryImagePrefab, _settings.categoryIndicatorTransform);
                categoryUIButton.Setup(_database.GetCategory(i));
                _settings.categoryUI.AddImageObject(categoryUIButton.image);
            }
            
            _settings.categoryUI.SetPointerImage(0);
            _settings.categoryUI.SetText(_database.GetCategory(0).catName);
            
            _inputWorker.Initialize(MoveRight, MoveLeft);
        }
        public void OnGameStageChange(GameStageSignal signal)
        {
            _isEnabled = signal.gameStage == Stage.Object;
        }
        public void OnPlaceablePanelOpened(IPlaceablePanelOpenSignal signal)
        {
            _signalBus.AbstractFire(new CategoryPageChangeSignal(_database.GetCategory(_pointer)));
        }
        public void OnObjectPanelPageChanged(ICategoryPanelChangeSignal signal)
        {
            _pointer = _database.GetIndex(signal.category.catName);
            _settings.categoryUI.SetPointerImage(_pointer);
            _settings.categoryUI.SetText(signal.category.catName);
        }
        private void SetPointer(int moveAmount)
        {
            if (_database.count < 0)
                return;
            
            if (_pointer + moveAmount < 0)
                moveAmount = _database.count - 1;

            if (_pointer + moveAmount > _database.count - 1)
                moveAmount = -(_database.count - 1);

            _pointer += moveAmount;
            var catergory = _database.GetCategory(_pointer);
            _signalBus.AbstractFire(new CategoryPageChangeSignal(catergory));
        }
        private void MoveRight(InputAction.CallbackContext context)
        {
            if (!_isEnabled)
                return;
            
            SetPointer(1);
        }
        private void MoveLeft(InputAction.CallbackContext context)
        {
            if (!_isEnabled)
                return;
            
            SetPointer(-1);
        }
    }
}