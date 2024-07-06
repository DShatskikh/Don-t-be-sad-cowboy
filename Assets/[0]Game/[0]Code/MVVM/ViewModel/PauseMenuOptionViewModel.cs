namespace Game
{
    public class PauseMenuOptionViewModel : UIPanelOptionViewModel
    {
        private PauseMenuOptionType _optionType;
        public PauseMenuOptionType OptionType { get => _optionType; }

        public PauseMenuOptionViewModel(string name, bool isSelected, PauseMenuOptionType optionType) : base(name, isSelected)
        {
            _optionType = optionType;
        }
    }
}