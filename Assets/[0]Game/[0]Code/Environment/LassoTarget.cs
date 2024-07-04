using UnityEngine;

namespace Game
{
    public class LassoTarget : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _lassoSpriteRenderer;
        
        private SpriteRenderer _spriteRenderer;
        
        private void OnEnable()
        {
            EventBus.LassoOn += OnLassoOn;
            EventBus.LassoOff += OnLassoOff;
        }

        private void OnDisable()
        {
            EventBus.LassoOn -= OnLassoOn;
            EventBus.LassoOff -= OnLassoOff;
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
    }
}