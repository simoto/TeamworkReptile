namespace TeamWorkGame.Data
{
    using System;
    using System.Media;
    using TeamWorkGame.GameObjects;
    using TeamWorkGame.Interfaces;

    public class KeyboardInterface : IUserInterface
    {
        private static int currentRow;
        private static int currentCol;

        public void ProcessInput(ConsoleKeyInfo pressedKey, Player player, ref SingleElement[,] currentMap, IRenderer renderer)
        {
            currentRow = player.Position.Row;
            currentCol = player.Position.Col;

            if (pressedKey.Key.Equals(ConsoleKey.LeftArrow))
            {
                this.Move(0, -1, Direction.Left, player, ref currentMap, renderer);
            }
            else if (pressedKey.Key.Equals(ConsoleKey.RightArrow))
            {
                this.Move(0, 1, Direction.Right, player, ref currentMap, renderer);
            }
            else if (pressedKey.Key.Equals(ConsoleKey.UpArrow))
            {
                this.Move(-1, 0, Direction.Up, player, ref currentMap, renderer);
            }
            else if (pressedKey.Key.Equals(ConsoleKey.DownArrow))
            {
                this.Move(1, 0, Direction.Down, player, ref currentMap, renderer);
            }
            else if (pressedKey.Key == ConsoleKey.S)
            {
                //// TODO ask player for pass/key
                var password = "TODO";
                SaveManager.Save(currentMap, player);
                SystemSounds.Asterisk.Play();
                Environment.Exit(0);
            }
            else if (pressedKey.Key == ConsoleKey.L)
            {
                ////load
                throw new NotImplementedException();
            }
            else if (pressedKey.Key == ConsoleKey.R)
            {
                //// restart level
                currentMap = LevelLoader.LoadLevel(player.Level);
                MapReader.SetPlayerPosition(player, currentMap);
                renderer.RenderMap(currentMap);
                renderer.RenderPlayer(player);
            }
            else if (pressedKey.Key == ConsoleKey.N)
            {
                // end game, start from level 1
                currentMap = LevelLoader.LoadLevel(1);
                MapReader.SetPlayerPosition(player, currentMap);
                player.Level = 1;
                player.Moves = 0;
                renderer.RenderMap(currentMap);
                renderer.RenderPlayer(player);
            }
        }

        private void Move(int rowMove, int colMove, Direction direction, Player player, ref SingleElement[,] currentMap, IRenderer renderer)
        {
            bool isNearBox = currentMap[currentRow + rowMove, currentCol + colMove].Symbol == 'K';

            if (currentMap[currentRow + rowMove, currentCol + colMove].IsSolid)
            {
                SystemSounds.Hand.Play();
            }
            else if (isNearBox && currentMap[currentRow + (2 * rowMove), currentCol + (2 * colMove)].IsSolid)
            {
                //// next to K is solid
                SystemSounds.Hand.Play();
            }
            else if (isNearBox && currentMap[currentRow + (2 * rowMove), currentCol + (2 * colMove)].Symbol == 'K')
            {
                SystemSounds.Hand.Play();
            }
            else if (isNearBox && currentMap[currentRow + (2 * rowMove), currentCol + (2 * colMove)].Symbol == ' ')
            {
                currentMap[currentRow + (2 * rowMove), currentCol + (2 * colMove)].Symbol = 'K';
                currentMap[currentRow + (2 * rowMove), currentCol + (2 * colMove)].Color = ConsoleColor.Cyan;
                currentMap[currentRow + rowMove, currentCol + colMove].Symbol = ' ';

                renderer.RenderSingleElement(currentMap[currentRow + (2 * rowMove), currentCol + (2 * colMove)], currentRow + (2 * rowMove), currentCol + (2 * colMove));
                renderer.RenderSingleElement(currentMap[currentRow + rowMove, currentCol + colMove], currentRow + rowMove, currentCol + colMove);
                renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);
                player.Move(direction);
                player.Moves++;
                currentRow = player.Position.Row;
                currentCol = player.Position.Col;
                SystemSounds.Asterisk.Play();
            }
            else if (isNearBox && currentMap[currentRow + (2 * rowMove), currentCol + (2 * colMove)].Symbol == '*')
            {
                currentMap[currentRow + (2 * rowMove), currentCol + (2 * colMove)].Symbol = '@';
                currentMap[currentRow + (2 * rowMove), currentCol + (2 * colMove)].IsSolid = true;
                currentMap[currentRow + rowMove, currentCol + colMove].Symbol = ' ';

                renderer.RenderSingleElement(currentMap[currentRow + (2 * rowMove), currentCol + (2 * colMove)], currentRow + (2 * rowMove), currentCol + (2 * colMove));
                renderer.RenderSingleElement(currentMap[currentRow + rowMove, currentCol + colMove], currentRow + rowMove, currentCol + colMove);
                renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);

                player.Move(direction);
                player.Moves++;
                currentRow = player.Position.Row;
                currentCol = player.Position.Col;
                SystemSounds.Asterisk.Play();
            }
            else if (isNearBox && currentMap[currentRow + (2 * rowMove), currentCol + (2 * colMove)].IsSolid)
            {
                SystemSounds.Hand.Play();
            }
            else if (!currentMap[currentRow + rowMove, currentCol + colMove].IsSolid)
            {
                renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);
                player.Move(direction);
                player.Moves++;
                currentRow = player.Position.Row;
                currentCol = player.Position.Col;
                SystemSounds.Asterisk.Play();
            }
        }       
    }
}