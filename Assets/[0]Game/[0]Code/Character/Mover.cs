using UnityEngine;

namespace Game
{
    public class Mover
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly CharacterView _view;
        private readonly CharacterData _data;

        private bool _isMove;

        public Mover(Rigidbody2D rigidbody2D, CharacterView view, CharacterData data)
        {
            _rigidbody = rigidbody2D;
            _view = view;
            _data = data;
        }

        public void Move(Vector2 direction, bool isRun)
        {
            var speed = isRun ? _data.RunSpeed : _data.Speed;
            direction = direction.normalized;
            _rigidbody.velocity = direction * speed;
            _isMove = true;

            _view.Walk(direction);
        }

        public void TryStopMove()
        {
            if (!_isMove)
                return;
            
            _rigidbody.velocity = Vector2.zero;
            _isMove = false;
            _view.Stay();
        }
    }
}
