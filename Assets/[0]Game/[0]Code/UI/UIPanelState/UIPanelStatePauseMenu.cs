using UnityEngine;

namespace Game
{
    public class UIPanelStatePauseMenu : UIPanelState
    {
        [SerializeField]
        private PauseMenuOptionSlotView _slotPrefab;
        
        [SerializeField]
        private Transform _root;
        
        [SerializeField]
        private PauseMenuOptionConfig _config;
        
        private void Start()
        {
            for (int i = 0; i < _config.Data.Count; i++)
            {
                var menuOption = _config.Data[i];
                var slot = Instantiate(_slotPrefab, _root);
                int rowIndex = i;
                int columnIndex = 0;
                var vm = new PauseMenuOptionViewModel(menuOption.Name, i == 0, menuOption.PauseMenuOptionType);
                _viewModels.Add(new Vector2(columnIndex, rowIndex), vm);
                slot.Init(vm);
            }
        }
        
        public override void HandleConfirmButtonClicked()
        {
            var vm = (PauseMenuOptionViewModel)_viewModels[_currentIndex];

            switch (vm.OptionType)
            {
                case PauseMenuOptionType.Continue:
                    _panelController.ResetCurrentPanelState();
                    break;
                case PauseMenuOptionType.Bag:
                    _panelController.SetPanelState<UIPanelStateBag>();
                    break;
                case PauseMenuOptionType.Setting:
                    
                    break;
                case PauseMenuOptionType.Exit:
                    
                    break;
            }
        }

        public override void HandleBackButtonClicked()
        {
            
        }

        public override void HandleSelectedSlotChanged(Vector2 vectorDelta)
        {
            var newIndex = _currentIndex + vectorDelta;
            
            if (_viewModels.TryGetValue(newIndex, out var model))
            {
                if (model != null)
                {
                    model.SetSelected(true);
                    var oldVM = _viewModels[_currentIndex];
                    oldVM.SetSelected(false);
                    _currentIndex = newIndex;
                }
            }
        }
    }
}