using UnityEngine;

namespace Game
{
    public class CharacterController : Controller
    {
        private readonly CharacterView _view;
        private readonly Mover _mover;
        private readonly CharacterData _data;

        public CharacterController(CharacterData data, CharacterView view)
        {
            _data = data;
            _view = view;
            _mover = new Mover(_data, _view);
        }

        public override void OnLassoDown()
        {
            if (!_data.IsLasso) 
                GameData.CharacterStateMachine.TrySwitchState<AimingLassoCharacterState>();
        }

        public override void OnLassoUp()
        {
            if (_data.IsLasso)
            {
                _data.Lasso.Target.LetGo();
                Object.Destroy(_data.Lasso.gameObject);
            }
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