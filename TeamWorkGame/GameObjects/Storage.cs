namespace TeamWorkGame.GameObjects
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using TeamWorkGame.Interfaces;

    public class Storage : IStorage
    {
        public void Save(IGame game)
        {
            string fileName = game.Player.Name + "&" + game.Player.Password + ".bin";
            string subDirectory = game.GameName + "/";
            string fileNameAndDirectory = @"../../Data/Saves/" + subDirectory + fileName;
            Stream stream = File.Create(fileNameAndDirectory);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(stream, game);
            stream.Close();
        }

        public IGame Load(string gameName, string userName, string password)
        {
            string fileName = userName + "&" + password + ".bin";
            string subDirectory = gameName + "/";
            string fileNameAndDirectory = @"../../Data/Saves/" + subDirectory + fileName;
            if (File.Exists(fileNameAndDirectory))
            {
                Stream stream = File.OpenRead(fileNameAndDirectory);
                BinaryFormatter deserializer = new BinaryFormatter();
                IGame game = (IGame)deserializer.Deserialize(stream);
                stream.Close();
                return game;
            }
            else
            {
                return null;
            }
        }
    }
}
