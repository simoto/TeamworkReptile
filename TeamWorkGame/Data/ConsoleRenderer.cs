namespace TeamWorkGame.Data
{
    using System;
    using TeamWorkGame.GameObjects;
    using TeamWorkGame.Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        private const ConsoleColor PlayerBackgroundColor = ConsoleColor.DarkRed;
        private const ConsoleColor PlayerColor = ConsoleColor.White;
        private const ConsoleColor BrickColor = ConsoleColor.DarkGray;
        private const ConsoleColor BackgroundColor = ConsoleColor.Black;
        private const char SymbolOfPlayer = 'H';

        public void RenderBrick(SingleElement brick, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = brick.Color;
            Console.Write(brick.Symbol);
        }

        public void RenderPlayer(Player hero)
        {
            Console.SetCursorPosition(hero.Position.Col, hero.Position.Row);
            Console.ForegroundColor = PlayerColor;
            Console.BackgroundColor = PlayerBackgroundColor;
            Console.Write(SymbolOfPlayer);
        }

        public void RenderMap(SingleElement[,] matrix)
        {
            Console.BackgroundColor = BackgroundColor;
            Console.Clear();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    this.RenderBrick(matrix[row, col], row, col);
                }
            }

            this.RenderMenu();
        }

        public void RenderString(string stringToWrite, ConsoleColor backgroundColor, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.BackgroundColor = backgroundColor;
            Console.Write(stringToWrite);
        }

        private void RenderMenu()
        {
            Console.SetCursorPosition(20, 3);
            Console.WriteLine("S => Save and exit.");

            Console.SetCursorPosition(20, 5);
            Console.WriteLine("L => Load previuos game.");

            Console.SetCursorPosition(20, 7);
            Console.WriteLine("R => Restart level.");

            Console.SetCursorPosition(20, 9);
            Console.WriteLine("N => Start new game.");
        }
    }
}