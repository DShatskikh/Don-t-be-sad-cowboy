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
            _line.SetPosition(0, GameData.CharacterData.transform.position);
            _line.SetPosition(1, Target.transform.position);
        }
    }
}