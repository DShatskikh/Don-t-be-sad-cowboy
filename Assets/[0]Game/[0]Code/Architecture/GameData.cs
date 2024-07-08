using UnityEngine;

namespace Game
{
    public static class GameData
    {
        public static CharacterStateMachine CharacterStateMachine { get; set; }
        public static CharacterData CharacterData { get; set; }
        public static AssetProvider AssetProvider { get; set; }
        public static PlayerInput Input { get; set; }
        public static CharacterFactory CharacterFactory { get; set; }
        public static SpriteRenderer BlackPanel { get; set; }
        public static CommandManager CommandManager { get; set; }
        public static Starter CoroutineRunner { get; set; }

        public static UIPanelStateController PanelController;
        public static PPEffectManager PPEffectManager;
    }
}