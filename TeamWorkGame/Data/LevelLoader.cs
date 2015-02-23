﻿namespace TeamWorkGame.Data
{
    using System;
    using System.IO;
    using System.Text;
    using TeamWorkGame.GameObjects;

    public static class LevelLoader
    {
        private const string filePath = @"../../Data/Levels/Level";
        private const int Matrix_Size = 10;
        private const int Max_Level = 5;

        public static SingleElement[,] LoadLevel(int level)
        {
            if (level <= 0 || Max_Level < level)
            {
                throw new ArgumentOutOfRangeException(string.Format("Valid level must be provided! Available levels 1-{0}.", Max_Level));
            }

            SingleElement[,] currentLevel = new SingleElement[Matrix_Size, Matrix_Size];
            string line;
            int lineCount = 0;
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(filePath + level + ".txt");
                while ((line = reader.ReadLine()) != null)
                {
                    for (int i = 0; i < Matrix_Size; i++)
                    {
                        ConsoleColor currentCollor;
                        bool isSolid = false;
                        if (line[i] == '#')
                        {
                            currentCollor = ConsoleColor.Gray;
                            isSolid = true;
                        }
                        else if (line[i] == '*')
                        {
                            currentCollor = ConsoleColor.Yellow;
                        }
                        else if (line[i] == 'K')
                        {
                            currentCollor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            currentCollor = ConsoleColor.Black;
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