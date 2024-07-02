using System;
using UnityEngine;

namespace Game
{
    public class CharacterView : MonoBehaviour
    {
        private Animator _animator;
        
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Walk(Vector2 direction)
        {
            _animator.SetFloat(Speed, 1);
            _animator.SetFloat(Vertical, direction.y);
            _animator.SetFloat(Horizontal, direction.x);
        }

        public void Stay()
        {
            _animator.SetFloat(Speed, 0);
        }
    }
}