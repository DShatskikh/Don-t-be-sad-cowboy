using UnityEngine;

namespace Game
{
    public class AimingLassoCharacterState : CharacterState
    {
        public override bool IsCanSwitch()
        {
            return true;
        }

        public override void Enter()
        {
            GameData.BlackPanel.gameObject.SetActive(true);
            GameData.Input.Controller = GameData.CharacterFactory.CreateLassoController();
        }

        public override void Exit()
        {
            GameData.BlackPanel.gameObject.SetActive(false);
        }
    }
}