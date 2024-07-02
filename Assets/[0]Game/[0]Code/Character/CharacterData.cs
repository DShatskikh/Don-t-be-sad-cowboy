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
    }
}