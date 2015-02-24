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

            if (pressedKey.Key.Equals(ConsoleKey.LeftArrow))
            {
                bool isLeftColBox = currentMap[currentRow, currentCol - 1].Symbol == 'K';

                if (currentMap[currentRow, currentCol - 1].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (isLeftColBox && currentMap[currentRow, currentCol - 2].IsSolid) 
                {
                    //// K , and k-- is solid
                    SystemSounds.Hand.Play();
                }
                else if (isLeftColBox && currentMap[currentRow, currentCol - 2].Symbol == 'K')
                {
                    SystemSounds.Hand.Play();
                }
                else if (isLeftColBox && currentMap[currentRow, currentCol - 2].Symbol == ' ')
                {
                    //// K-- is ' '
                    ////K--
                    currentMap[currentRow, currentCol - 2].Symbol = 'K';
                    ////H--
                    currentMap[currentRow, currentCol - 1].Symbol = ' ';

                    renderer.RenderSingleElement(currentMap[currentRow, currentCol - 2], currentRow, currentCol - 2);
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol - 1], currentRow, currentCol - 1);
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);

                    player.Move(Direction.Left);
                    player.Moves++;
                    currentCol = player.Position.Col;
                    SystemSounds.Asterisk.Play();
                }
                else if (isLeftColBox && currentMap[currentRow, currentCol - 2].Symbol == '*')
                {
                    //// k, and k-- is *
                    ////K--
                    currentMap[currentRow, currentCol - 2].Symbol = '@';
                    currentMap[currentRow, currentCol - 2].IsSolid = true;
                    ////H--
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
                    currentMap[currentRow, currentCol + 2].Symbol = '@';
                    currentMap[currentRow, currentCol + 2].IsSolid = true;
                    currentMap[currentRow, currentCol + 1].Symbol = ' ';

                    renderer.RenderSingleElement(currentMap[currentRow, currentCol + 2], currentRow, currentCol + 2);
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol + 1], currentRow, currentCol + 1);
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);

                    player.Move(Direction.Right);
                    player.Moves++;
                    currentCol = player.Position.Col;
                    SystemSounds.Asterisk.Play();
                }
                else if (isRightColBox && currentMap[currentRow, currentCol + 2].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (!currentMap[currentRow, currentCol + 1].IsSolid)
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
                else if (isUpRowBox && currentMap[currentRow - 2, currentCol].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (isUpRowBox && currentMap[currentRow - 2, currentCol].Symbol == ' ')
                {
                    currentMap[currentRow - 2, currentCol].Symbol = 'K';
                    currentMap[currentRow - 1, currentCol].Symbol = ' ';

                    renderer.RenderSingleElement(currentMap[currentRow - 2, currentCol], currentRow - 2, currentCol);
                    renderer.RenderSingleElement(currentMap[currentRow - 1, currentCol], currentRow - 1, currentCol);
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);

                    player.Move(Direction.Up);
                    player.Moves++;
                    currentRow = player.Position.Row;
                    SystemSounds.Asterisk.Play();
                }
                else if (isUpRowBox && currentMap[currentRow - 2, currentCol].Symbol == '*')
                {
                    currentMap[currentRow - 2, currentCol].Symbol = '@';
                    currentMap[currentRow - 2, currentCol].IsSolid = true;
                    currentMap[currentRow - 1, currentCol].Symbol = ' ';

                    renderer.RenderSingleElement(currentMap[currentRow - 2, currentCol], currentRow - 2, currentCol);
                    renderer.RenderSingleElement(currentMap[currentRow - 1, currentCol], currentRow - 1, currentCol);
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);

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
                    currentRow = player.Position.Row;
                    SystemSounds.Asterisk.Play();
                }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.DownArrow))
            {
                bool isDownRowBox = currentMap[currentRow + 1, currentCol].Symbol == 'K';

                if (currentMap[currentRow + 1, currentCol].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (isDownRowBox && currentMap[currentRow + 2, currentCol].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (isDownRowBox && currentMap[currentRow + 2, currentCol].Symbol == 'K')
                {
                    SystemSounds.Hand.Play();
                }
                else if (isDownRowBox && currentMap[currentRow + 2, currentCol].Symbol == ' ')
                {
                    currentMap[currentRow + 2, currentCol].Symbol = 'K';
                    currentMap[currentRow + 1, currentCol].Symbol = ' ';

                    renderer.RenderSingleElement(currentMap[currentRow + 2, currentCol], currentRow + 2, currentCol);
                    renderer.RenderSingleElement(currentMap[currentRow + 1, currentCol], currentRow + 1, currentCol);
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);

                    player.Move(Direction.Down);
                    player.Moves++;
                    currentRow = player.Position.Row;
                    SystemSounds.Asterisk.Play();
                }
                else if (isDownRowBox && currentMap[currentRow + 2, currentCol].Symbol == '*')
                {
                    currentMap[currentRow + 2, currentCol].Symbol = '@';
                    currentMap[currentRow + 2, currentCol].IsSolid = true;
                    currentMap[currentRow + 1, currentCol].Symbol = ' ';

                    renderer.RenderSingleElement(currentMap[currentRow + 2, currentCol], currentRow + 2, currentCol);
                    renderer.RenderSingleElement(currentMap[currentRow + 1, currentCol], currentRow + 1, currentCol);
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);

                    player.Move(Direction.Down);
                    player.Moves++;
                    currentRow = player.Position.Row;
                    SystemSounds.Asterisk.Play();
                }
                else if (isDownRowBox && currentMap[currentRow + 2, currentCol].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (!currentMap[currentRow + 1, currentCol].IsSolid)
                {
                    renderer.RenderSingleElement(currentMap[currentRow, currentCol], currentRow, currentCol);
                    player.Move(Direction.Down);
                    player.Moves++;
                    currentRow = player.Position.Row;
                    SystemSounds.Asterisk.Play();
                }
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
    }
}