using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "AssetProvider", menuName = "Data/AssetProvider", order = 30)]
    public class AssetProvider : ScriptableObject
    {
        public GameObject AimPrefab;
        public Lasso LassoPrefab;
    }
}