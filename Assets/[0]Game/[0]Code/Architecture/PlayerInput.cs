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
                _controller.OnEnter();
            }
            
        }

        private void Update()
        {
            if (_controller == null)
                return;
            
            if (Input.GetButtonDown("Submit")) 
                _controller.OnSubmitDown();
            
            if (Input.GetButton("Submit")) 
                _controller.OnSubmit();
            
            if (Input.GetButtonUp("Submit")) 
                _controller.OnSubmitUp();
            
            if (Input.GetButtonDown("Cancel")) 
                _controller.OnCancelDown();
            
            if (Input.GetButton("Cancel")) 
                _controller.OnCancel();
            
            if (Input.GetButtonUp("Cancel")) 
                _controller.OnCancelUp();
            
            _controller.OnAxisRaw(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
            _controller.OnUpdate();
        }
    }
}