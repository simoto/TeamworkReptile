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
            if (level <= 0 || 6 <= level)
            {
                throw new ArgumentOutOfRangeException("Valid level must be provided! Available levels 1-5.");
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

            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("Error: Could not read file from disk. Original error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Something went wrong. Original error: " + ex.Message);
            }

            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return currentLevel;
        }
    }
}