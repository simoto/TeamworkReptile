namespace TeamWorkGame.Interfaces
{
    public interface IStorage
    {
        bool Save(IGame game);

        IGame Load(string gameName, string userName, string password);
    }
}
