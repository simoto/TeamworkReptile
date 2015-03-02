namespace TeamWorkGame.GameObjects
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security;
    using TeamWorkGame.Interfaces;

    public class Storage : IStorage
    {
        public bool Save(IGame game)
        {
            string fileName = game.Player.Name + "&" + game.Player.Password + ".bin";
            string subDirectory = game.GameName + "/";
            string fileNameAndDirectory = @"../../Data/Saves/" + subDirectory + fileName;

            try
            {
                using (Stream stream = File.Create(fileNameAndDirectory))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(stream, game);
                }
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (SerializationException)
            {
                return false;
            }
            catch (SecurityException)
            {
                return false;
            }
            catch (PathTooLongException)
            {
                return false;
            }
            catch (DirectoryNotFoundException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
            catch (NotSupportedException)
            {
                return false;
            }

            return true;
        }

        public IGame Load(string gameName, string userName, string password)
        {
            string fileName = userName + "&" + password + ".bin";
            string subDirectory = gameName + "/";
            string fileNameAndDirectory = @"../../Data/Saves/" + subDirectory + fileName;

            if (File.Exists(fileNameAndDirectory))
            {
                try
                {
                    using (Stream stream = File.OpenRead(fileNameAndDirectory))
                    {
                        BinaryFormatter deserializer = new BinaryFormatter();
                        IGame game = (IGame)deserializer.Deserialize(stream);
                        stream.Close();
                        return game;
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    return null;
                }
                catch (ArgumentNullException)
                {
                    return null;
                }
                catch (ArgumentException)
                {
                    return null;
                }
                catch (FileNotFoundException)
                {
                    return null;
                }
                catch (SerializationException)
                {
                    return null;
                }
                catch (SecurityException)
                {
                    return null;
                }
                catch (PathTooLongException)
                {
                    return null;
                }
                catch (DirectoryNotFoundException)
                {
                    return null;
                }
                catch (IOException)
                {
                    return null;
                }
                catch (NotSupportedException)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
