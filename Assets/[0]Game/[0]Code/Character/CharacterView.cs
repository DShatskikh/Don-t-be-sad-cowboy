using System;
using UnityEngine;

namespace Game
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _lassoZone;
        
        private Animator _animator;
        private Vector2 _previousDirection;
        
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int State = Animator.StringToHash("State");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Walk(Vector2 direction, float speed)
        {
            if (_previousDirection.x == -direction.x || _previousDirection.y == -direction.y || direction.x == 0 || direction.y == 0)
                _previousDirection = direction;
            
            _animator.SetFloat(Speed, speed > 0.01f ? 1 : 0);
            _animator.SetFloat(Vertical, _previousDirection.y);
            _animator.SetFloat(Horizontal, _previousDirection.x);
        }

        public void Stay()
        {
            _animator.SetFloat(Speed, 0);
        }

        public void LassoZoneActivate(bool isActive)
        {
            //_lassoZone.gameObject.SetActive(isActive);
            _animator.SetInteger(State, isActive ? 0 : -1);
        }

        public void LassoWhite()
        {
            _lassoZone.color = Color.white;
        }

        public void LassoRed()
        {
            _lassoZone.color = Color.red;
        }
    }
}