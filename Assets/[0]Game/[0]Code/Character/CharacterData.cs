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
        public float Speed => _speed;
        public float RunSpeed => _runSpeed;
        public bool IsLasso => Lasso;
        public bool IsRun { get; set; }
        public Rigidbody2D Rigidbody { get; set; }
        public Lasso Lasso { get; set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}