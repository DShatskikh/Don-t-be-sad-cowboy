﻿using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "AssetProvider", menuName = "Data/AssetProvider", order = 30)]
    public class AssetProvider : ScriptableObject
    {
        public LassoAimView AimPrefab;
        public Lasso LassoPrefab;
    }
}