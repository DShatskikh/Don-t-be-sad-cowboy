using System;
using UnityEngine;

namespace Game
{
    public class PlayerInput : MonoBehaviour
    {
        private Controller _controller;
        
        public Controller Controller
        {
            get => _controller;
            set
            {
                _controller?.OnExit();
                _controller = value;
                _controller?.OnEnter();
            }
        }

        public Action OnConfirmButtonClicked { get; set; }
        public Action<int, int> OnSlotIndexChanged { get; set; }

        public Action OnBackButtonClicked;

        private void Update()
        {
            if (Input.GetButtonUp("Menu")) 
                GameData.PanelController.TogglePanelState<UIPanelStatePauseMenu>();

            if (Input.GetButtonDown("Submit"))
            {
                OnConfirmButtonClicked?.Invoke();
                _controller?.OnSubmitDown();
            }

            if (Input.GetButton("Submit")) 
                _controller?.OnSubmit();
            
            if (Input.GetButtonUp("Submit")) 
                _controller?.OnSubmitUp();

            if (Input.GetButtonDown("Cancel"))
            {
                _controller?.OnCancelDown();
                OnBackButtonClicked?.Invoke();
            }

            if (Input.GetButton("Cancel")) 
                _controller?.OnCancel();
            
            if (Input.GetButtonUp("Cancel")) 
                _controller?.OnCancelUp();

            if (Input.GetButtonDown("Lasso")) 
                _controller?.OnLassoDown();
            
            if (Input.GetButtonUp("Lasso")) 
                _controller?.OnLassoUp();

            var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
            {
                _controller?.OnSlotIndexChanged(direction);
                OnSlotIndexChanged?.Invoke(-(int)direction.x, -(int)direction.y);
            }

            _controller?.OnAxisRaw(direction);
            _controller?.OnUpdate();
        }
    }
}