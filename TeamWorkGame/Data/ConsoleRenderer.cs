namespace TeamWorkGame.Data
{
    using System;
    using TeamWorkGame.GameObjects;
    using TeamWorkGame.Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        private const ConsoleColor Player_BackgroundColor = ConsoleColor.DarkRed;
        private const ConsoleColor Player_Color = ConsoleColor.White;
        private const ConsoleColor Brick_Color = ConsoleColor.DarkGray;
        private const ConsoleColor Background_Color = ConsoleColor.Black;
        private const char Symbol_Of_Player = 'H';

        public void RenderBrick(SingleElement brick, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = brick.Color;
            Console.Write(brick.Symbol);
        }

        public void RenderPlayer(Player hero)
        {
            Console.SetCursorPosition(hero.Position.Col, hero.Position.Row);
            Console.ForegroundColor = Player_Color;
            Console.BackgroundColor = Player_BackgroundColor;
            Console.Write(Symbol_Of_Player);
        }

        public void RenderMap(SingleElement[,] matrix)
        {
            Console.BackgroundColor = Background_Color;
            Console.Clear();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    RenderBrick(matrix[row, col], row, col);
                }

            }

            RenderMenu();
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