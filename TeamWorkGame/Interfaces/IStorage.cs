namespace TeamWorkGame.Interfaces
{
    public interface IStorage
    {
        void Save(IGame game);

        IGame Load(string gameName, string userName, string password);
    }
}
