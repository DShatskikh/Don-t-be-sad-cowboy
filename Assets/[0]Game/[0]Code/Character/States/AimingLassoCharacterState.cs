using System.Collections.Generic;
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
            GameData.CommandManager.StartCommands(
                new List<Command>()
                {
                    new ShowBackCommand(new CommandData())
                });   

            GameData.Input.Controller = GameData.CharacterFactory.CreateLassoController();
        }

        public override void Exit()
        {
            GameData.CommandManager.StartCommands(
                new List<Command>()
                {
                    new HideBackCommand(new CommandData())
                });   
        }
    }
}