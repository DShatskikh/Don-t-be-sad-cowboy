using System;
using UnityEngine;

namespace Game
{
    public class Starter : MonoBehaviour
    {
        [SerializeField]
        private CharacterView _characterView;
        
        [SerializeField]
        private CharacterData _characterData;
        
        [SerializeField]
        private AssetProvider _assetProvider;

        [SerializeField]
        private PlayerInput _input;

        [SerializeField]
        private SpriteRenderer _blackPanel;

        [SerializeField]
        private UIPanelStateController _panelController;
        
        private void Awake()
        {
            GameData.AssetProvider = _assetProvider;
            GameData.CharacterData = _characterData;
            GameData.CharacterFactory = new CharacterFactory(_characterData, _characterView);
            GameData.Input = _input;
            GameData.CharacterStateMachine = new CharacterStateMachine();
            GameData.BlackPanel = _blackPanel;
            GameData.PanelController = _panelController;
        }
    }
}