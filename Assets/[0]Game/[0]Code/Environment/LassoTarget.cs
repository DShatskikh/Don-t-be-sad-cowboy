using UnityEngine;

namespace Game
{
    public class LassoTarget : MonoBehaviour
    {
        [SerializeField]
        private float _differenceY = 0.5f;
        
        [SerializeField]
        private SpriteRenderer _lassoSpriteRenderer;
        
        private SpriteRenderer _spriteRenderer;
        
        public float DifferenceY => _differenceY;
        
        private void OnEnable()
        {
            SignalBus.LassoOn += OnLassoOn;
            SignalBus.LassoOff += OnLassoOff;
        }

        private void OnDisable()
        {
            SignalBus.LassoOn -= OnLassoOn;
            SignalBus.LassoOff -= OnLassoOff;
        }

        public void Grab()
        {
            _lassoSpriteRenderer.gameObject.SetActive(true);
        }

        public void LetGo()
        {
            _lassoSpriteRenderer.gameObject.SetActive(false);
        }
        
        private void OnLassoOn()
        {
            _spriteRenderer.gameObject.SetActive(false);
        }

        private void OnLassoOff()
        {
            _spriteRenderer.gameObject.SetActive(true);
        }

        public void Move(Vector2 moveDirection, float distance)
        {
            var lineDirection = (Mathf.Abs(moveDirection.y) > Mathf.Abs(moveDirection.x) 
                ? Vector2.up : Vector2.right).normalized * moveDirection;
            
            transform.position += (Vector3)lineDirection * Time.deltaTime * distance * 1;
        }
    }
}