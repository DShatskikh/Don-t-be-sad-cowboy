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
    }
}