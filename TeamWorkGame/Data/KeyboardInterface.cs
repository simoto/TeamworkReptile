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
                Move(0, -1, Direction.Left, player, ref currentMap, renderer);
            }
            else if (pressedKey.Key.Equals(ConsoleKey.RightArrow))
            {
                Move(0, 1, Direction.Right, player, ref currentMap, renderer);
            }
            else if (pressedKey.Key.Equals(ConsoleKey.UpArrow))
            {
                Move(-1, 0, Direction.Up, player, ref currentMap, renderer);
            }
            else if (pressedKey.Key.Equals(ConsoleKey.DownArrow))
            {
                Move(1, 0, Direction.Down, player, ref currentMap, renderer);
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
            if (currentMap[player.Position.Row + rowMove, player.Position.Col + colMove].IsSolid)
            {
                SystemSounds.Hand.Play();
            }
            else if (currentMap[player.Position.Row + rowMove, player.Position.Col + colMove].Symbol == 'K'
                && currentMap[player.Position.Row + (2 * rowMove), player.Position.Col + (2 * colMove)].IsSolid)
            {
                //// next to K is solid
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

                player.Move(direction);
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

                player.Move(direction);
                player.Moves++;
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
