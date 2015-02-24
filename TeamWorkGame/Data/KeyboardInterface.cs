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
                ////var password = "TODO";
                SaveManager.Save(currentMap, player);
                SystemSounds.Asterisk.Play();
                Environment.Exit(0);
            }
            else if (pressedKey.Key == ConsoleKey.L)
            {
                //// TODO
                ////load
                throw new NotImplementedException();
            }
            else if (pressedKey.Key == ConsoleKey.R)
            {
                //// restart level
                currentMap = LevelLoader.LoadLevel(player.Level);
                MapReader.SetPlayerPosition(player, currentMap);
                renderer.RenderMap(currentMap);
                renderer.RenderInGameMenu();
                renderer.RenderPlayer(player);
            }
            else if (pressedKey.Key == ConsoleKey.N)
            {
                //// end game, start from level 1
                currentMap = LevelLoader.LoadLevel(1);
                MapReader.SetPlayerPosition(player, currentMap);
                player.Level = 1;
                player.Moves = 0;
                renderer.RenderMap(currentMap);
                renderer.RenderInGameMenu();
                renderer.RenderPlayer(player);
            }
        }

        private void Move(int rowMove, int colMove, Direction direction, Player player, ref SingleElement[,] currentMap, IRenderer renderer)
        {
            int playerRow = player.Position.Row;
            int playerCol = player.Position.Col;
            int newRow = playerRow + rowMove;
            int newCol = playerCol + colMove;
            int rowNextToNewRow = playerRow + (2 * rowMove);
            int colNextToNewCol = playerCol + (2 * colMove);

            bool isNearBox = currentMap[newRow, newCol].Symbol == 'K';

            if (currentMap[newRow, newCol].IsSolid)
            {
                SystemSounds.Hand.Play();
            }
            else if (isNearBox && (currentMap[rowNextToNewRow, colNextToNewCol].IsSolid 
                || currentMap[rowNextToNewRow, colNextToNewCol].Symbol == 'K'))
            {
                //// next to K is solid or another K
                SystemSounds.Hand.Play();
            }
            else if (isNearBox && currentMap[rowNextToNewRow, colNextToNewCol].Symbol == ' ')
            {
                currentMap[rowNextToNewRow, colNextToNewCol].Symbol = 'K';
                currentMap[rowNextToNewRow, colNextToNewCol].Color = ConsoleColor.Cyan;
                currentMap[newRow, newCol].Symbol = ' ';

                renderer.RenderSingleElement(currentMap[rowNextToNewRow, colNextToNewCol], rowNextToNewRow, colNextToNewCol);
                renderer.RenderSingleElement(currentMap[newRow, newCol], newRow, newCol);
                renderer.RenderSingleElement(currentMap[playerRow, playerCol], playerRow, playerCol);
                player.Move(direction);
                player.Moves++;
                playerRow = player.Position.Row;
                playerCol = player.Position.Col;
            }
            else if (isNearBox && currentMap[rowNextToNewRow, colNextToNewCol].Symbol == '*')
            {
                currentMap[rowNextToNewRow, colNextToNewCol].Symbol = '@';
                currentMap[rowNextToNewRow, colNextToNewCol].IsSolid = true;
                currentMap[newRow, newCol].Symbol = ' ';

                renderer.RenderSingleElement(currentMap[rowNextToNewRow, colNextToNewCol], rowNextToNewRow, colNextToNewCol);
                renderer.RenderSingleElement(currentMap[newRow, newCol], newRow, newCol);
                renderer.RenderSingleElement(currentMap[playerRow, playerCol], playerRow, playerCol);

                player.Move(direction);
                player.Moves++;
                playerRow = player.Position.Row;
                playerCol = player.Position.Col;
                SystemSounds.Asterisk.Play();
            }
            else if (!currentMap[newRow, newCol].IsSolid)
            {
                renderer.RenderSingleElement(currentMap[playerRow, playerCol], playerRow, playerCol);
                player.Move(direction);
                player.Moves++;
                playerRow = player.Position.Row;
                playerCol = player.Position.Col;
            }
        }       
    }
}