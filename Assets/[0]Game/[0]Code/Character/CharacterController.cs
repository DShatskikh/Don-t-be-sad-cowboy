using UnityEngine;

namespace Game
{
    public class CharacterController : Controller
    {
        private CharacterView _view;
        private Mover _mover;
        private CharacterData _data;

        public CharacterController(CharacterData data, CharacterView view)
        {
            _data = data;
            _view = view;
            _mover = new Mover(_data, _view);
        }

        public override void OnSubmitDown()
        {
            GameData.CharacterStateMachine.TrySwitchState<AimingLassoCharacterState>();
        }
        
        public override void OnCancelDown()
        {
            _data.IsRun = true;
        }

        public override void OnCancelUp()
        {
            _data.IsRun = false;
        }

        public override void OnAxisRaw(Vector2 direction)
        {
            if (direction.magnitude != 0)
                _mover.Move(direction);
            else
                _mover.TryStopMove();
        }
    }
}