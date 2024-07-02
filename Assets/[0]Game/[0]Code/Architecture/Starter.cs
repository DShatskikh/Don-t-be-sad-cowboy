using System;
using UnityEngine;

namespace Game
{
    public class Starter : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _character;

        private void Awake()
        {
            GameData.Character = _character;
        }
    }
}