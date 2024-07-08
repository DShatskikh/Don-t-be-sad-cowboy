using System;
using UnityEngine;

namespace Game
{
    public class Lasso : MonoBehaviour
    {
        private LineRenderer _line;

        public LassoTarget Target;
        
        private void Awake()
        {
            _line = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            var characterPosition = GameData.CharacterData.transform.position;
            var distance = Vector2.Distance(Target.transform.position, characterPosition);
            
            if (distance > StringConstants.LassoSize)
            {
                var moveDirection = (characterPosition - Target.transform.position).normalized;
                Target.Move(moveDirection, distance);
            }
            
            _line.SetPosition(0, characterPosition);
            _line.SetPosition(1, Target.transform.position);
        }
    }
}