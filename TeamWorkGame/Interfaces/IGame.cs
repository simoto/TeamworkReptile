namespace TeamWorkGame.Interfaces
{
    using TeamWorkGame.Data;
    using TeamWorkGame.GameObjects;

    public interface IGame
    {
        void Init();

        void Move(Direction deirection);

        void Save();

        void Load(string userName, string password);

        void RestartLevel();

        void StartNewGame();
    }
}
