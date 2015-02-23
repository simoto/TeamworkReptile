namespace TeamWorkGame.Data
{
    using System;
    using System.IO;
    using System.Text;
    using TeamWorkGame.GameObjects;

    public static class LevelLoader
    {
        private const string FilePath = @"../../Data/Levels/Level";
        private const int MatrixSize = 10;
        private const int MaxLevel = 5;
        private const ConsoleColor SolidColor = ConsoleColor.Gray;
        private const ConsoleColor TargetColor = ConsoleColor.Yellow;
        private const ConsoleColor BarrelColor = ConsoleColor.Cyan;
        private const ConsoleColor EmptyColor = ConsoleColor.Black;

        public static SingleElement[,] LoadLevel(int level)
        {
            if (level <= 0 || MaxLevel < level)
            {
                throw new ArgumentOutOfRangeException(string.Format("Valid level must be provided! Available levels 1-{0}.", MaxLevel));
            }

            SingleElement[,] currentLevel = new SingleElement[MatrixSize, MatrixSize];
            string line;
            int lineCount = 0;
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(FilePath + level + ".txt");
                while ((line = reader.ReadLine()) != null)
                {
                    for (int i = 0; i < MatrixSize; i++)
                    {
                        ConsoleColor currentCollor;
                        bool isSolid = false;
                        if (line[i] == '#')
                        {
                            currentCollor = SolidColor;
                            isSolid = true;
                        }
                        else if (line[i] == '*')
                        {
                            currentCollor = TargetColor;
                        }
                        else if (line[i] == 'K')
                        {
                            currentCollor = BarrelColor;
                        }
                        else
                        {
                            currentCollor = EmptyColor;
                        }

                        currentLevel[lineCount, i] = new SingleElement(currentCollor, line[i], isSolid);                        
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