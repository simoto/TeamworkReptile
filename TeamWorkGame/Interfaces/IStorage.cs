namespace TeamWorkGame.Interfaces
{
    public interface IStorage
    {
        void Save(IGame game);

        IGame Load(string userName, string password);
    }
}
