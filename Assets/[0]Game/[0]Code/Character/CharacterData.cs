using System;
using UnityEngine;

namespace Game
{
    public class CharacterData : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _runSpeed;

        [SerializeField]
        private CharacterView _view;
        
        private Vector2 _previousPosition;
        
        public float Speed => _speed;
        public float RunSpeed => _runSpeed;
        public float CurrentSpeed;
        public bool IsLasso => Lasso;
        public bool IsRun { get; set; }
        public Rigidbody2D Rigidbody { get; set; }
        public Lasso Lasso { get; set; }

        public CharacterView View => _view;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            CurrentSpeed = (_previousPosition - (Vector2)transform.position).magnitude;
            _previousPosition = transform.position;
        }
    }
}