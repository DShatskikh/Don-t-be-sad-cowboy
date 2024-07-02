namespace Game
{
    public abstract class GameState
    {
        public abstract void OnEnter();
        public abstract bool CanSwitchToState<T>();
    }
}