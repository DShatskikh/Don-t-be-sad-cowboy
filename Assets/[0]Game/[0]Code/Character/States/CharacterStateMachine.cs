namespace Game
{
    public class CharacterStateMachine
    {
        private CharacterState _state;

        public CharacterStateMachine()
        {
            TrySwitchState<ResearchCharacterState>();
        }
        
        public bool TrySwitchState<T>() where T : CharacterState, new()
        {
            if (_state != null)
            {
                if (!_state.IsCanSwitch())
                    return false;
            
                _state.Exit();
            }

            _state = new T();
            _state.Enter();
            return true;
        }
    }
}