namespace TeamWorkGame.Data
{
    using System;
    using TeamWorkGame.GameObjects;
    using TeamWorkGame.Interfaces;

    class ConsoleRenderer : IRenderer
    {
        private void RenderBrick(SingleElement brick, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.BackgroundColor = brick.Color;
            Console.Write(brick.Symbol);
        }

        private void RenderVisualElementInConsole(VisualElement element, int row, int col)
        {
            for (int r = 0; r < element.ElementMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < element.ElementMatrix.GetLength(1); c++)
                {
                    RenderBrick(element.ElementMatrix[r, c], row + r, col + c);
                }
            }
        }

        public void RenderHero(Player hero)
        {
            Console.SetCursorPosition(hero.Position.Col, hero.Position.Row);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write('H');
        }

        public void RenderMap(VisualElement[,] matrix)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            int currentRow = 0, currentCol = 0;
            int stepsPerRow = matrix[0, 0].ElementMatrix.GetLength(0);
            int stepsPerCol = matrix[0, 0].ElementMatrix.GetLength(1);

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    RenderVisualElementInConsole(matrix[r, c], currentRow, currentCol);
                    currentCol += stepsPerCol;
                }
                currentRow += stepsPerRow;
                currentCol = 0;
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