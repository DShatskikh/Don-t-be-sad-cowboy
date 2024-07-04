namespace Game
{
    public class ResearchCharacterState : CharacterState
    {
        public override bool IsCanSwitch()
        {
            return true;
        }

        public override void Enter()
        {
            GameData.Input.Controller = GameData.CharacterFactory.CreateCharacterController();
        }

        public override void Exit()
        {
            
        }
    }
}