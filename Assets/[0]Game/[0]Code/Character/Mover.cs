using UnityEngine;

namespace Game
{
    public class Mover
    {
        private readonly CharacterView _view;
        private readonly CharacterData _data;

        private bool _isMove;

        public Mover(CharacterData data, CharacterView view)
        {
            _data = data;
            _view = view;
        }

        public void Move(Vector2 direction)
        {
            var speed = _data.IsRun ? _data.RunSpeed : _data.Speed;
            direction = direction.normalized;
            _data.Rigidbody.velocity = direction * speed;
            _isMove = true;

            _view.Walk(direction);
        }

        public void TryStopMove()
        {
            if (!_isMove)
                return;
            
            _data.Rigidbody.velocity = Vector2.zero;
            _isMove = false;
            _view.Stay();
        }
    }
}
