namespace TeamWorkGame.Interfaces
{
    using TeamWorkGame.GameObjects;

    public interface IStorage
    {
        void Save(Save save);

        Save Load(string userName, string password);
    }
}
