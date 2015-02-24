namespace TeamWorkGame.Data
{
    using System;
    using System.Media;
    using TeamWorkGame.GameObjects;
    using TeamWorkGame.Interfaces;

    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInput(ConsoleKeyInfo pressedKey, Player player, ref SingleElement[,] currentMap, IRenderer renderer)
        {
            int currentRow = player.Position.Row;
            int currentCol = player.Position.Col;

            renderer.RenderMoves(player);

            if (pressedKey.Key.Equals(ConsoleKey.LeftArrow))
            {
                Move(0, -1, Direction.Left, player, ref currentMap, renderer);
            }
                else if (isLeftColBox && currentMap[currentRow, currentCol - 2].IsSolid) 
            {
                Move(0, 1, Direction.Right, player, ref currentMap, renderer);
            }
                else if (isLeftColBox && currentMap[currentRow, currentCol - 2].Symbol == 'K')
            {
                Move(-1, 0, Direction.Up, player, ref currentMap, renderer);
            }
                else if (isLeftColBox && currentMap[currentRow, currentCol - 2].Symbol == ' ')
            {
                Move(1, 0, Direction.Down, player, ref currentMap, renderer);
            }
                else if (isLeftColBox && currentMap[currentRow, currentCol - 2].Symbol == '*')
            {
                    currentMap[currentRow, currentCol - 2].Symbol = '@';
                    currentMap[currentRow, currentCol - 2].IsSolid = true;
                    currentMap[currentRow, currentCol - 1].Symbol = ' ';

                    renderer.RenderSingleElement(currentMap[currentRow, currentCol - 2], currentRow, currentCol - 2);
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol - 1], currentRow, currentCol - 1);
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);

                    player.Move(Direction.Left);
                    player.Moves++;
                    currentCol = player.Position.Col;
                SystemSounds.Asterisk.Play();
            }
                else if (isLeftColBox && currentMap[currentRow, currentCol - 2].IsSolid)
            {
                    SystemSounds.Hand.Play();
            }
                else if (!currentMap[currentRow, currentCol - 1].IsSolid)
            {
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);
                    player.Move(Direction.Left);
                    player.Moves++;
                    currentCol = player.Position.Col;
                    SystemSounds.Asterisk.Play();
            }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.RightArrow))
            {
                bool isRightColBox = currentMap[currentRow, currentCol + 1].Symbol == 'K';

                if (currentMap[currentRow, currentCol + 1].IsSolid)
                {
                    SystemSounds.Hand.Play();
            }
                else if (isRightColBox && currentMap[currentRow, currentCol + 2].IsSolid)
                {
                    SystemSounds.Hand.Play();
        }
                else if (isRightColBox && currentMap[currentRow, currentCol + 2].Symbol == 'K')
                {
                    SystemSounds.Hand.Play();
                }
                else if (isRightColBox && currentMap[currentRow, currentCol + 2].Symbol == ' ')
                {
                    currentMap[currentRow, currentCol + 2].Symbol = 'K';
                    currentMap[currentRow, currentCol + 2].Color = ConsoleColor.Cyan;                  
                    currentMap[currentRow, currentCol + 1].Symbol = ' ';

                    renderer.RenderSingleElement(currentMap[currentRow, currentCol + 2], currentRow, currentCol + 2);
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol + 1], currentRow, currentCol + 1);
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);

                    player.Move(Direction.Right);
                    player.Moves++;
                    currentCol = player.Position.Col;
                    SystemSounds.Asterisk.Play();
                }
                else if (isRightColBox && currentMap[currentRow, currentCol + 2].Symbol == '*')
        {
            if (currentMap[player.Position.Row + rowMove, player.Position.Col + colMove].IsSolid)
            {
                SystemSounds.Hand.Play();
            }
            else if (currentMap[player.Position.Row + rowMove, player.Position.Col + colMove].Symbol == 'K'
                && currentMap[player.Position.Row + (2 * rowMove), player.Position.Col + (2 * colMove)].IsSolid)
            {
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);
                    player.Move(Direction.Right);
                    player.Moves++;
                    currentCol = player.Position.Col;
                    SystemSounds.Asterisk.Play();
                }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.UpArrow))
            {
                bool isUpRowBox = currentMap[currentRow - 1, currentCol].Symbol == 'K';

                if (currentMap[currentRow - 1, currentCol].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (isUpRowBox && currentMap[currentRow - 2, currentCol].Symbol == 'K')
                {
                SystemSounds.Hand.Play();
            }
            else if (currentMap[player.Position.Row + rowMove, player.Position.Col + colMove].Symbol == 'K'
                && currentMap[player.Position.Row + (2 * rowMove), player.Position.Col + (2 * colMove)].Symbol == 'K')
            {
                SystemSounds.Hand.Play();
            }
            else if (currentMap[player.Position.Row + rowMove, player.Position.Col + colMove].Symbol == 'K' && currentMap[player.Position.Row + (2 * rowMove), player.Position.Col + (2 * colMove)].Symbol == ' ')
            {
                //// next to K is ' '
                currentMap[player.Position.Row + (2 * rowMove), player.Position.Col + (2 * colMove)].Symbol = 'K';
                //// H--
                currentMap[player.Position.Row + rowMove, player.Position.Col + colMove].Symbol = ' ';

                renderer.RenderBrick(currentMap[player.Position.Row + (2 * rowMove), player.Position.Col + (2 * colMove)], player.Position.Row + (2 * rowMove), player.Position.Col + (2 * colMove));

                renderer.RenderBrick(currentMap[player.Position.Row + rowMove, player.Position.Col + colMove], player.Position.Row + rowMove, player.Position.Col + colMove);

                renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);

                    player.Move(Direction.Up);
                    player.Moves++;
                    currentRow = player.Position.Row;
                    SystemSounds.Asterisk.Play();
                }
                else if (isUpRowBox && currentMap[currentRow - 2, currentCol].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (!currentMap[currentRow - 1, currentCol].IsSolid)
                {
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);
                    player.Move(Direction.Up);
                player.Moves++;
                SystemSounds.Asterisk.Play();
            }
            else if (currentMap[player.Position.Row + rowMove, player.Position.Col + colMove].Symbol == 'K' && currentMap[player.Position.Row + (2 * rowMove), player.Position.Col + (2 * colMove)].Symbol == '*')
            {
                //// next to K is *
                ////K--
                currentMap[player.Position.Row + (2 * rowMove), player.Position.Col + (2 * colMove)].Symbol = '@';
                currentMap[player.Position.Row + (2 * rowMove), player.Position.Col + (2 * colMove)].IsSolid = true;
                ////H--
                currentMap[player.Position.Row + rowMove, player.Position.Col + colMove].Symbol = ' ';

                renderer.RenderBrick(currentMap[player.Position.Row + (2 * rowMove), player.Position.Col + (2 * colMove)], player.Position.Row + (2 * rowMove), player.Position.Col + (2 * colMove));

                renderer.RenderBrick(currentMap[player.Position.Row + rowMove, player.Position.Col + colMove], player.Position.Row + rowMove, player.Position.Col + colMove);

                renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);

                    player.Move(Direction.Down);
                player.Moves++;
                    currentRow = player.Position.Row;
                SystemSounds.Asterisk.Play();
            }
            else if (currentMap[player.Position.Row + rowMove, player.Position.Col + colMove].Symbol == 'K' && currentMap[player.Position.Row + (2 * rowMove), player.Position.Col + (2 * colMove)].IsSolid)
            {
                SystemSounds.Hand.Play();
            }
            else if (!currentMap[player.Position.Row + rowMove, player.Position.Col + colMove].IsSolid)
            {
                renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);
                player.Move(direction);
                player.Moves++;
                SystemSounds.Asterisk.Play();
            }
        }
    }
}
