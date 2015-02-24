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
                MapReader.SetPlayerPossition(player, currentMap);
                renderer.RenderMap(currentMap);
                renderer.RenderPlayer(player);
            }
            else if (pressedKey.Key == ConsoleKey.N)
            {
                // end game, start from level 1
                currentMap = LevelLoader.LoadLevel(1);
                MapReader.SetPlayerPossition(player, currentMap);
                player.Level = 1;
                player.Moves = 0;
                renderer.RenderMap(currentMap);
                renderer.RenderPlayer(player);
            }
        }

        private void Move(int rowMove, int colMove, Direction direction, Player player, ref SingleElement[,] currentMap, IRenderer renderer)
        {
            int newRow = player.Position.Row + rowMove;
            int newCol = player.Position.Col + colMove;
            int nextToNewRow = player.Position.Row + (2 * rowMove);
            int nextToNewCol = player.Position.Col + (2 * colMove);
            int playerRow = player.Position.Row;
            int playerCol = player.Position.Col;

            if (currentMap[newRow, newCol].IsSolid)
            {
                SystemSounds.Hand.Play();
            }
            else if (currentMap[newRow, newCol].Symbol == 'K'
                && currentMap[nextToNewRow, nextToNewCol].IsSolid)
            {
                //// next to K is solid
                SystemSounds.Hand.Play();
            }
            else if (currentMap[newRow, newCol].Symbol == 'K'
                && currentMap[nextToNewRow, nextToNewCol].Symbol == 'K')
            {
                SystemSounds.Hand.Play();
            }
            else if (currentMap[newRow, newCol].Symbol == 'K' && currentMap[nextToNewRow, nextToNewCol].Symbol == ' ')
            {
                //// next to K is ' '
                currentMap[nextToNewRow, nextToNewCol].Symbol = 'K';
                //// H--
                currentMap[newRow, newCol].Symbol = ' ';

                renderer.RenderBrick(currentMap[nextToNewRow, nextToNewCol], nextToNewRow, nextToNewCol);

                renderer.RenderBrick(currentMap[newRow, newCol], newRow, newCol);

                renderer.RenderBrick(currentMap[playerRow, playerCol], playerRow, playerCol);

                player.Move(direction);
                player.Moves++;
            }
            else if (currentMap[newRow, newCol].Symbol == 'K' && currentMap[nextToNewRow, nextToNewCol].Symbol == '*')
            {
                //// next to K is *
                ////K--
                currentMap[nextToNewRow, nextToNewCol].Symbol = '@';
                currentMap[nextToNewRow, nextToNewCol].IsSolid = true;
                ////H--
                currentMap[newRow, newCol].Symbol = ' ';

                renderer.RenderBrick(currentMap[nextToNewRow, nextToNewCol], nextToNewRow, nextToNewCol);

                renderer.RenderBrick(currentMap[newRow, newCol], newRow, newCol);

                renderer.RenderBrick(currentMap[playerRow, playerCol], playerRow, playerCol);

                player.Move(direction);
                player.Moves++;
                SystemSounds.Asterisk.Play();
            }
            else if (currentMap[newRow, newCol].Symbol == 'K' && currentMap[nextToNewRow, nextToNewCol].IsSolid)
            {
                SystemSounds.Hand.Play();
            }
            else if (!currentMap[newRow, newCol].IsSolid)
            {
                renderer.RenderBrick(currentMap[playerRow, playerCol], playerRow, playerCol);
                player.Move(direction);
                player.Moves++;
            }
        }
    }
}
