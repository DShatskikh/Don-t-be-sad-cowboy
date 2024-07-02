using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(CharacterData))]
    public class CharacterController : MonoBehaviour
    {
        [SerializeField]
        private CharacterView _view;
        
        private Mover _mover;
        private CharacterData _data;

        private void Awake()
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            _data = GetComponent<CharacterData>();
            _mover = new Mover(rigidbody, _view, _data);
        }

        private void Update()
        {
            var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            var isRun = Input.GetButton("Cancel");
            
            if (direction.magnitude != 0)
                _mover.Move(direction, isRun);
            else
                _mover.TryStopMove();
            
            
        }
    }
}