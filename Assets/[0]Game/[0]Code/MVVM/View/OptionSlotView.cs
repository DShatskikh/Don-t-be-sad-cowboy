using TMPro;
using UnityEngine;

namespace Game
{
    public abstract class OptionSlotView : MonoBehaviour
    {
        [SerializeField]
        protected TextMeshProUGUI _slotName;
        
        [SerializeField]
        private GameObject _selectedBlock;
        
        protected UIPanelOptionViewModel _viewModel;

        private bool _isSelected;

        public void Init(UIPanelOptionViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.SelectionChanged += SetSelected;
        
            SetSelected(viewModel.IsSelected);
            OnInit();
        }

        public void SetSelected(bool isSelected)
        {
            _isSelected = isSelected;
            _selectedBlock.SetActive(isSelected);

            if (isSelected)
            {
                _slotName.text = $"[<Color=#FC7200>{_viewModel.Name}</Color>]";
                Canvas.ForceUpdateCanvases();
            }
            else
            {
                _slotName.text = _viewModel.Name;
            }
        }

        public abstract void OnInit();
    }
}