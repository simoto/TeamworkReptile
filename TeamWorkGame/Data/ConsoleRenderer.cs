namespace TeamWorkGame.Data
{
    using System;
    using TeamWorkGame.GameObjects;
    using TeamWorkGame.Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        private void RenderBrick(char brick, int row, int col)
        {
            Console.SetCursorPosition(row, col);
            Console.Write(brick);
        }

        private void RenderVisualElementInConsole(char element, int row, int col)
        {
            RenderBrick(element, row, col);
        }

        public void RenderHero(Player hero)
        {
            Console.SetCursorPosition(hero.Position.Col, hero.Position.Row);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write('H');
        }

        public void RenderMap(char[,] matrix)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    RenderVisualElementInConsole(matrix[r, c], r, c);
                }

            }
        }

        public void RenderString(string stringToWrite, ConsoleColor background, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.BackgroundColor = background;
            Console.Write(stringToWrite);
        }
    }
}