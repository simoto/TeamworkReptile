namespace TeamWorkGame.Data
{
    using System;
    using TeamWorkGame.GameObjects;
    using TeamWorkGame.Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        private const string MenuSaveMessage = "S => Save and exit.";
        private const string MenuLoadMessage = "L => Load previuos game.";
        private const string MenuRestartMessage = "R => Restart level.";
        private const string MenuNewGameMessage = "N => Start new game.";
        private const string MenuNextLevelMessage = "Space => Start next level.";
        private const int MenuRenderColumn = 20;
        private const ConsoleColor PlayerBackgroundColor = ConsoleColor.DarkRed;
        private const ConsoleColor PlayerColor = ConsoleColor.White;
        private const ConsoleColor MoovesColor = ConsoleColor.Red;
        private const ConsoleColor LevelColor = ConsoleColor.Green;
        private const ConsoleColor BrickColor = ConsoleColor.DarkGray;
        private const ConsoleColor BackgroundColor = ConsoleColor.Black;
        private const char SymbolOfPlayer = 'H';

        public void RenderSingleElement(SingleElement brick, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = brick.Color;
            Console.Write(brick.Symbol);
        }

        public void RenderPlayer(Player hero)
        {
            Console.SetCursorPosition(hero.Position.Col, hero.Position.Row);
            Console.ForegroundColor = PlayerColor;
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
                    this.RenderSingleElement(matrix[row, col], row, col);
                }
            }
        }

        public void RenderString(string stringToWrite, ConsoleColor backgroundColor, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.BackgroundColor = backgroundColor;
            Console.Write(stringToWrite);
        }

        public void RenderInGameMenu()
        {
            Console.SetCursorPosition(MenuRenderColumn, 2);
            Console.WriteLine(MenuSaveMessage);
            Console.SetCursorPosition(MenuRenderColumn, 4);
            Console.WriteLine(MenuLoadMessage);
            Console.SetCursorPosition(MenuRenderColumn, 6);
            Console.WriteLine(MenuRestartMessage);
            Console.SetCursorPosition(MenuRenderColumn, 8);
            Console.WriteLine(MenuNewGameMessage);
            Console.SetCursorPosition(MenuRenderColumn, 10);
            Console.WriteLine(MenuNextLevelMessage);
        }

        public void RenderMoves(int moves)
        {
            Console.SetCursorPosition(2, 12);
            Console.ForegroundColor = MoovesColor;
            Console.Write("Moves: {0}", moves);
        }


        public void RenderLevel(int level)
        {
            Console.SetCursorPosition(2, 14);
            Console.ForegroundColor = LevelColor;
            Console.Write("Level: {0}", level);
        }
    }
}