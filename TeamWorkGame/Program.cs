namespace TeamWorkGame
{
    using System;

    class Program
    {
        private const string availableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static int moovesCount = 0;
        private const int matrixDefaultSize = 4;

        private static void Main(string[] args)
        {

            char[,] matrix = GenerateCardsMatrix(matrixDefaultSize);

            bool[,] openedCards = new bool[matrixDefaultSize, matrixDefaultSize];

            PrintCharMatrix(matrix);
            PrintBoolMatrix(openedCards);


        }

        private static char[,] GenerateCardsMatrix(int size)
        {
            if (size < 2 || 6 < size)
            {
                throw new ArgumentOutOfRangeException("Size is out of range!");
            }

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

        private static void PrintBoolMatrix(bool[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == false)
                    {
                        Console.Write("0 ");
                    }
                    else
                    {
                        Console.Write("1 ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
