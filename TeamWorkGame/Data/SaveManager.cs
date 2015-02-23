namespace TeamWorkGame.Data
{
    using System;
    using System.IO;
    using System.Text;
    using TeamWorkGame.GameObjects;

    public class SaveManager
    {
        private const string filePath = @"../../Data/Saves/";
        private const int Matrix_Size = 10;
        private const int Max_Level = 5;
        private const int Name_Max_Length = 10;
        private const int Password_Max_Length = 10;

        public static Save Load(string name, string password)
        {
            if (name == string.Empty || Name_Max_Length < name.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid name!");
            }

            if (password == string.Empty || Password_Max_Length < password.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid password!");
            }

            char[,] currentLevel = new char[Matrix_Size, Matrix_Size];
            string line;

            var save = new Save();
            StreamReader streamReader = null;

            using (streamReader = new StreamReader(filePath + name + "&" + password + ".txt"))
            {
                for (int row = 0; row < Matrix_Size; row++)
                {
                    line = streamReader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    for (int col = 0; col < Matrix_Size; col++)
                    {
                        currentLevel[row, col] = line[col];
                    }
                }

                save.Matrix = currentLevel;
                
                if ((line = streamReader.ReadLine()) != null)
                {
                    save.Level = int.Parse(line);
                }

                if ((line = streamReader.ReadLine()) != null)
                {
                    save.Moves = int.Parse(line);
                }
            }
            
            return save;
        }

        public static void Save(SingleElement[,] matrix, Player player)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Matrix is null!");
            }

            if (player.Name == string.Empty || Name_Max_Length < player.Name.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid name!");
            }

            if (player.Password == string.Empty || Password_Max_Length < player.Password.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid password!");
            }

            using (StreamWriter sw = new StreamWriter(filePath + player.Name + "&" + player.Password + ".txt"))
            {
                StringBuilder sb = new StringBuilder(Matrix_Size);

                for (int row = 0; row < Matrix_Size; row++)
                {
                    for (int col = 0; col < Matrix_Size; col++)
                    {
                        sb.Append(matrix[row, col].ToString());
                    }

                    sw.WriteLine(sb.ToString());
                    sb.Clear();
                }

                sw.WriteLine(player.Level);
                sw.WriteLine(player.Moves);
            }
        }
    }
}