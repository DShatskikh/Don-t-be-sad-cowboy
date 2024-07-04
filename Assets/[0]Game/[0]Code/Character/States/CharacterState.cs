namespace Game
{
    public abstract class CharacterState
    {
        public abstract bool IsCanSwitch();
        public abstract void Enter();
        public abstract void Exit();
    }
}