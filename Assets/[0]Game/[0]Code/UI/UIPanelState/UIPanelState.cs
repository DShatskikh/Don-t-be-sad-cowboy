using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class UIPanelState : MonoBehaviour
    {
        private PlayerInput _input;
        private Controller _previousController;
        
        protected Dictionary<Vector2, UIPanelOptionViewModel> _viewModels = new Dictionary<Vector2, UIPanelOptionViewModel>();
        protected Vector2 _currentIndex;
        protected UIPanelStateController _panelController;
        
        public abstract void HandleConfirmButtonClicked();
        public abstract void HandleBackButtonClicked();
        public abstract void HandleSelectedSlotChanged(Vector2 vectorDelta);

        public virtual void Activate(bool active)
        {
            gameObject.SetActive(active);

            if (active)
            {
                _input = GameData.Input;
                _panelController = GameData.PanelController;
            
                _previousController = _input.Controller;
                _input.Controller = null;
                
                Subscribe();
            }
            else
            {
                _input.Controller = _previousController;
                
                Unsubscribe();
            }
        }
        
        private void Subscribe()
        {
            _input.OnBackButtonClicked += OnBackButtonClicked;
            _input.OnConfirmButtonClicked += OnConfirmButtonClicked;
            _input.OnSlotIndexChanged += OnSlotIndexChanged;
        }

        private void Unsubscribe()
        {
            _input.OnBackButtonClicked -= OnBackButtonClicked;
            _input.OnConfirmButtonClicked -= OnConfirmButtonClicked;
            _input.OnSlotIndexChanged -= OnSlotIndexChanged;
        }
        
        private void OnConfirmButtonClicked()
        {
            if (gameObject.activeSelf)
            {
                HandleConfirmButtonClicked();
            }
        }

        private void OnBackButtonClicked()
        {
            if (gameObject.activeSelf)
            {
                HandleBackButtonClicked();
            }
        }

        private void OnSlotIndexChanged(int x, int y)
        {
            if (gameObject.activeSelf)
            {
                HandleSelectedSlotChanged(new Vector2(x, y));
            }
        }
    }
}