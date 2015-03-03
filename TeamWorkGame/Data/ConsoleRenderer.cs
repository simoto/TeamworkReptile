namespace TeamWorkGame.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using TeamWorkGame.GameObjects;
    using TeamWorkGame.Interfaces;

    [Serializable]
    public class ConsoleRenderer : IRenderer
    {
        private const string MenuSaveLabel = "S => Save.";
        private const string MenuLoadLabel = "L => Load previuos game.";
        private const string MenuRestartLabel = "R => Restart level.";
        private const string MenuNewGameLabel = "N => Start new game.";
        private const string MenuGameOverLabel = "GAME OVER";
        private const string MenuExitLabel = "E => EXIT";
        private const int MenuRenderColumn = 28;
        private const int MenuStartRow = 1;
        private const int PlayerInfoRenderColumn = 12;
        private const int PlayerInfoStartRow = 1;
        private const int GameOverLabbelColumn = 12;
        private const int GameOverLabbelRow = 7;
        private const int RankingStartColumn = 2;
        private const int RankingRow = 12;
        private const ConsoleColor PlayerBackgroundColor = ConsoleColor.DarkRed;
        private const ConsoleColor PlayerColor = ConsoleColor.White;
        private const ConsoleColor UserNameColor = ConsoleColor.Blue;
        private const ConsoleColor MoovesColor = ConsoleColor.Red;
        private const ConsoleColor LevelColor = ConsoleColor.Green;
        private const ConsoleColor BrickColor = ConsoleColor.DarkGray;
        private const ConsoleColor BackgroundColor = ConsoleColor.Black;
        private const ConsoleColor GameOverLabbelColor = ConsoleColor.Red;
        private const ConsoleColor RankingLabbelColor = ConsoleColor.Red;
        private const char SymbolOfPlayer = 'H';

        public event PropertyChangedEventHandler PropertyChanged;

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
            int row = MenuStartRow;
            Console.SetCursorPosition(MenuRenderColumn, row);
            Console.Write(MenuSaveLabel);
            row += 2;
            Console.SetCursorPosition(MenuRenderColumn, row);
            Console.Write(MenuLoadLabel);
            row += 2;
            Console.SetCursorPosition(MenuRenderColumn, row);
            Console.Write(MenuRestartLabel);
            row += 2;
            Console.SetCursorPosition(MenuRenderColumn, row);
            Console.Write(MenuNewGameLabel);
            row += 2;
            Console.SetCursorPosition(MenuRenderColumn, row);
            Console.Write(MenuExitLabel);
        }

        public void RenderPlayerInfo(Player player)
        {
            int row = PlayerInfoStartRow;
            Console.SetCursorPosition(PlayerInfoRenderColumn, row);
            Console.ForegroundColor = UserNameColor;
            Console.Write("Moves: {0}", player.Name);
            row += 2;

            Console.SetCursorPosition(PlayerInfoRenderColumn, row);
            Console.ForegroundColor = LevelColor;
            Console.Write("Level: {0}", player.Level);
            row += 2;

            Console.SetCursorPosition(PlayerInfoRenderColumn, row);
            Console.ForegroundColor = MoovesColor;
            Console.Write("Moves: {0}", player.Moves);
        }

        public void RenderGameOver(List<Participant> participants)
        {
            Console.SetCursorPosition(GameOverLabbelColumn, GameOverLabbelRow);
            Console.ForegroundColor = GameOverLabbelColor;
            Console.Write(MenuGameOverLabel);
            this.RenderRanking(participants);
        }

        private void RenderRanking(List<Participant> participants)
        {
            int row = RankingRow;
            Console.SetCursorPosition(RankingStartColumn, row);
            Console.ForegroundColor = RankingLabbelColor;
            Console.Write("=========RANKING=========");
            row += 2;
            Console.SetCursorPosition(RankingStartColumn, row);
            Console.Write("# \t Name \t\tLevel \t\tMoves");
            for (int i = 0; i < participants.Count; i++)
            {
                var user = participants[i];
                row += 2;
                Console.SetCursorPosition(RankingStartColumn, row);
                Console.Write("{0}. \t{1} \t\t{2} \t\t{3}", i + 1, user.Name, user.Level, user.Moves);
            }
        }
    }
}