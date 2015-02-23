namespace TeamWorkGame.Data
{
    using System;
    using System.IO;
    using System.Text;
    using TeamWorkGame.GameObjects;

    public class SaveManager
    {
        private const string FilePath = @"../../Data/Saves/";
        private const int MatrixSize = 10;
        private const int MaxLevel = 5;
        private const int NameMaxLength = 10;
        private const int PasswordMaxLength = 10;

        public static Save Load(string name, string password)
        {
            if (name == string.Empty || NameMaxLength < name.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid name!");
            }

            if (password == string.Empty || PasswordMaxLength < password.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid password!");
            }

            char[,] currentLevel = new char[MatrixSize, MatrixSize];
            string line;

            var save = new Save();
            StreamReader streamReader = null;

            using (streamReader = new StreamReader(FilePath + name + "&" + password + ".txt"))
            {
                for (int row = 0; row < MatrixSize; row++)
                {
                    line = streamReader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    for (int col = 0; col < MatrixSize; col++)
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

            if (player.Name == string.Empty || NameMaxLength < player.Name.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid name!");
            }

            if (player.Password == string.Empty || PasswordMaxLength < player.Password.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid password!");
            }

            using (StreamWriter sw = new StreamWriter(FilePath + player.Name + "&" + player.Password + ".txt"))
            {
                StringBuilder sb = new StringBuilder(MatrixSize);

                for (int row = 0; row < MatrixSize; row++)
                {
                    for (int col = 0; col < MatrixSize; col++)
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