namespace Game
{
    public class CharacterFactory
    {
        private CharacterData _data;
        private CharacterView _view;

        public CharacterFactory(CharacterData data, CharacterView view)
        {
            _data = data;
            _view = view;
        }
        
        public CharacterController CreateCharacterController()
        {
            return new CharacterController(_data, _view);
        }
        
        public LassoAimController CreateLassoController()
        {
            return new LassoAimController(_data, _view);
        }
    }
}