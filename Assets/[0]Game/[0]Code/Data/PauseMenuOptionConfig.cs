using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "PauseMenu", menuName = "Data/PauseMenu", order = 35)]
    public class PauseMenuOptionConfig : ScriptableObject
    {
        [SerializeField]
        private List<PauseMenuOptionModel> _data;

        public List<PauseMenuOptionModel> Data { get => _data; }
    }
}