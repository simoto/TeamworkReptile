namespace TeamWorkGame.Interfaces
{
    using TeamWorkGame.Data;
    using TeamWorkGame.GameObjects;

    public interface IGame
    {
        void Move(Direction deirection);

        void Save(Save save);

        Save Load(string userName, string password);

        void RestartLevel();

        void StartNewGame();
    }
}
