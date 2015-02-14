namespace TeamWorkGame
{
    using System;

    class Program
    {
        private const string availableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static void Main(string[] args)
        {
            char[,] matrix = GenerateCardsMatrix(4);

            PrintCharMatrix(matrix);


        }

        private static char[,] GenerateCardsMatrix(int size)
        {
            int charsUsed = size * size / 2;

            string actualChars = availableChars.Substring(0, charsUsed) + availableChars.Substring(0, charsUsed);

            char[] chars = actualChars.ToCharArray();

            Random ran = new Random();

            for (int i = 0; i < chars.Length; i++)
            {
                int newPossition = ran.Next(0, chars.Length);

                char temp = chars[i];
                chars[i] = chars[newPossition];
                chars[newPossition] = temp;
            }

            char[,] matrix = new char[size, size];

            int index = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[index];
                    index++;
                }
            }

            return matrix;
        }

        private static void PrintCharMatrix(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("{0}", matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
