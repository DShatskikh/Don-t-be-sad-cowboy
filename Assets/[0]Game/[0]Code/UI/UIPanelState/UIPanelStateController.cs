﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class UIPanelStateController : MonoBehaviour
    {
        [SerializeField]
        private List<UIPanelState> _panels;

        private UIPanelState _activePanel;
        
        public void SetPanelState<T>() where T : UIPanelState
        {
            _activePanel?.Activate(false);
            var newPanel = GetPanelByType<T>();
            _activePanel = newPanel;
            newPanel.Activate(true);
        }

        public void ResetCurrentPanelState()
        {
            _activePanel.Activate(false);
            _activePanel = null;
        }
        
        public void TogglePanelState<T>() where T : UIPanelState
        {
            if (GetPanelByType<T>().gameObject.activeSelf)
                ResetCurrentPanelState();
            else
                SetPanelState<T>();
        }

        private UIPanelState GetPanelByType<T>() where T : UIPanelState
        {
            foreach (var panel in _panels.OfType<T>())
                return panel;

            throw new Exception("Not Panel State");
        }
    }
}