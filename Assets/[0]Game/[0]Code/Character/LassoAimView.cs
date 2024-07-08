using System;
using UnityEngine;

namespace Game
{
    public class LassoAimView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void ColorGrab()
        {
            _spriteRenderer.color = Color.white;
        }

        public void NotColorGrab()
        {
            _spriteRenderer.color = Color.red;
        }
    }
}