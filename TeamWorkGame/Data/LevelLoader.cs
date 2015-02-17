namespace TeamWorkGame.Data
{
    using System;
    using System.IO;
    using System.Text;

    public class LevelLoader
    {
        const string filePath = @"../../Data/Levels/Level";

        public char[,] LoadLevel(int level)
        {
            if (level <= 0)
            {
                throw new ArgumentException("Valid level must be provided!");
            }

            char[,] currentLevel = new char[10, 10];
            string line;
            int lineCount = 0;
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(filePath + level + ".txt");
                while ((line = reader.ReadLine()) != null)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        currentLevel[lineCount, i] = line[i];
                    }

                    lineCount++;
                }
            }

            catch (IOException ex)
            {
                throw new Exception("Error: Could not read file from disk. Original error: " + ex.Message);
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return currentLevel;
        }
    }
}