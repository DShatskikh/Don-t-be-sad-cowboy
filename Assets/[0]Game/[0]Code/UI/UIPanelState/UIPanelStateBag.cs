using UnityEngine;

namespace Game
{
    public class UIPanelStateBag : UIPanelState
    {
        [SerializeField]
        private GameObject _canvas;
        
        public override void Activate(bool active)
        {
            base.Activate(active);
            
            if (active)
                _canvas.SetActive(true);
        }

        public override void HandleConfirmButtonClicked()
        {
            throw new System.NotImplementedException();
        }

        public override void HandleBackButtonClicked()
        {
            _panelController.SetPanelState<UIPanelStatePauseMenu>();
        }

        public override void HandleSelectedSlotChanged(Vector2 vectorDelta)
        {
            if (_viewModels.Count == 0)
                return;
            
            throw new System.NotImplementedException();
        }
    }
}