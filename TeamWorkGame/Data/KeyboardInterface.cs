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
                if (currentMap[player.Position.Row, player.Position.Col - 1].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (currentMap[player.Position.Row, player.Position.Col - 1].Symbol == 'K' 
                    && currentMap[player.Position.Row, player.Position.Col - 2].IsSolid) 
                {
                    //// K , and k-- is solid
                    SystemSounds.Hand.Play();
                }
                else if (currentMap[player.Position.Row, player.Position.Col - 1].Symbol == 'K' 
                    && currentMap[player.Position.Row, player.Position.Col - 2].Symbol == 'K')
                {
                    SystemSounds.Hand.Play();
                }
                else if (currentMap[player.Position.Row, player.Position.Col - 1].Symbol == 'K' && currentMap[player.Position.Row, player.Position.Col - 2].Symbol == ' ')
                {
                    //// K-- is ' '
                    ////K--
                    currentMap[player.Position.Row, player.Position.Col - 2].Symbol = 'K';
                    ////H--
                    currentMap[player.Position.Row, player.Position.Col - 1].Symbol = ' ';

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col - 2], player.Position.Row, player.Position.Col - 2);

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col - 1], player.Position.Row, player.Position.Col - 1);

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);

                    player.Move(Direction.Left);
                    player.Moves++;
                    SystemSounds.Asterisk.Play();
                }
                else if (currentMap[player.Position.Row, player.Position.Col - 1].Symbol == 'K' && currentMap[player.Position.Row, player.Position.Col - 2].Symbol == '*')
                {
                    //// k, and k-- is *
                    ////K--
                    currentMap[player.Position.Row, player.Position.Col - 2].Symbol = '@';
                    currentMap[player.Position.Row, player.Position.Col - 2].IsSolid = true;
                    ////H--
                    currentMap[player.Position.Row, player.Position.Col - 1].Symbol = ' ';

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col - 2], player.Position.Row, player.Position.Col - 2);

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col - 1], player.Position.Row, player.Position.Col - 1);

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);

                    player.Move(Direction.Left);
                    player.Moves++;
                    SystemSounds.Asterisk.Play();
                }
                else if (currentMap[player.Position.Row, player.Position.Col - 1].Symbol == 'K' && currentMap[player.Position.Row, player.Position.Col - 2].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (!currentMap[player.Position.Row, player.Position.Col - 1].IsSolid)
                {
                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);
                    player.Move(Direction.Left);
                    player.Moves++;
                    SystemSounds.Asterisk.Play();
                }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.RightArrow))
            {
                if (currentMap[player.Position.Row, player.Position.Col + 1].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (currentMap[player.Position.Row, player.Position.Col + 1].Symbol == 'K' && currentMap[player.Position.Row, player.Position.Col + 2].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (currentMap[player.Position.Row, player.Position.Col + 1].Symbol == 'K' && currentMap[player.Position.Row, player.Position.Col + 2].Symbol == 'K')
                {
                    SystemSounds.Hand.Play();
                }
                else if (currentMap[player.Position.Row, player.Position.Col + 1].Symbol == 'K' && currentMap[player.Position.Row, player.Position.Col + 2].Symbol == ' ')
                {
                    currentMap[player.Position.Row, player.Position.Col + 2].Symbol = 'K';
                    currentMap[player.Position.Row, player.Position.Col + 1].Symbol = ' ';

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col + 2], player.Position.Row, player.Position.Col + 2);

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col + 1], player.Position.Row, player.Position.Col + 1);

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);

                    player.Move(Direction.Right);
                    player.Moves++;
                    SystemSounds.Asterisk.Play();
                }
                else if (currentMap[player.Position.Row, player.Position.Col + 1].Symbol == 'K' && currentMap[player.Position.Row, player.Position.Col + 2].Symbol == '*')
                {
                    currentMap[player.Position.Row, player.Position.Col + 2].Symbol = '@';
                    currentMap[player.Position.Row, player.Position.Col + 2].IsSolid = true;
                    currentMap[player.Position.Row, player.Position.Col + 1].Symbol = ' ';

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col + 2], player.Position.Row, player.Position.Col + 2);

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col + 1], player.Position.Row, player.Position.Col + 1);

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);

                    player.Move(Direction.Right);
                    player.Moves++;
                    SystemSounds.Asterisk.Play();
                }
                else if (currentMap[player.Position.Row, player.Position.Col + 1].Symbol == 'K' && currentMap[player.Position.Row, player.Position.Col + 2].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (!currentMap[player.Position.Row, player.Position.Col + 1].IsSolid)
                {
                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);
                    player.Move(Direction.Right);
                    player.Moves++;
                    SystemSounds.Asterisk.Play();
                }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.UpArrow))
            {
                if (currentMap[player.Position.Row - 1, player.Position.Col].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (currentMap[player.Position.Row - 1, player.Position.Col].Symbol == 'K' && currentMap[player.Position.Row - 2, player.Position.Col].Symbol == 'K')
                {
                    SystemSounds.Hand.Play();
                }
                else if (currentMap[player.Position.Row - 1, player.Position.Col].Symbol == 'K' && currentMap[player.Position.Row - 2, player.Position.Col].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (currentMap[player.Position.Row - 1, player.Position.Col].Symbol == 'K' && currentMap[player.Position.Row - 2, player.Position.Col].Symbol == ' ')
                {
                    currentMap[player.Position.Row - 2, player.Position.Col].Symbol = 'K';
                    currentMap[player.Position.Row - 1, player.Position.Col].Symbol = ' ';

                    renderer.RenderBrick(currentMap[player.Position.Row - 2, player.Position.Col], player.Position.Row - 2, player.Position.Col);

                    renderer.RenderBrick(currentMap[player.Position.Row - 1, player.Position.Col], player.Position.Row - 1, player.Position.Col);

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);

                    player.Move(Direction.Up);
                    player.Moves++;
                    SystemSounds.Asterisk.Play();
                }
                else if (currentMap[player.Position.Row - 1, player.Position.Col].Symbol == 'K' && currentMap[player.Position.Row - 2, player.Position.Col].Symbol == '*')
                {
                    currentMap[player.Position.Row - 2, player.Position.Col].Symbol = '@';
                    currentMap[player.Position.Row - 2, player.Position.Col].IsSolid = true;
                    currentMap[player.Position.Row - 1, player.Position.Col].Symbol = ' ';

                    renderer.RenderBrick(currentMap[player.Position.Row - 2, player.Position.Col], player.Position.Row - 2, player.Position.Col);

                    renderer.RenderBrick(currentMap[player.Position.Row - 1, player.Position.Col], player.Position.Row - 1, player.Position.Col);

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);

                    player.Move(Direction.Up);
                    player.Moves++;
                    SystemSounds.Asterisk.Play();
                }
                else if (currentMap[player.Position.Row - 1, player.Position.Col].Symbol == 'K' && currentMap[player.Position.Row - 2, player.Position.Col].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (!currentMap[player.Position.Row - 1, player.Position.Col].IsSolid)
                {
                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);
                    player.Move(Direction.Up);
                    player.Moves++;
                    SystemSounds.Asterisk.Play();
                }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.DownArrow))
            {
                if (currentMap[player.Position.Row + 1, player.Position.Col].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (currentMap[player.Position.Row + 1, player.Position.Col].Symbol == 'K' && currentMap[player.Position.Row + 2, player.Position.Col].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (currentMap[player.Position.Row + 1, player.Position.Col].Symbol == 'K' && currentMap[player.Position.Row + 2, player.Position.Col].Symbol == 'K')
                {
                    SystemSounds.Hand.Play();
                }
                else if (currentMap[player.Position.Row + 1, player.Position.Col].Symbol == 'K' && currentMap[player.Position.Row + 2, player.Position.Col].Symbol == ' ')
                {
                    currentMap[player.Position.Row + 2, player.Position.Col].Symbol = 'K';
                    currentMap[player.Position.Row + 1, player.Position.Col].Symbol = ' ';

                    renderer.RenderBrick(currentMap[player.Position.Row + 2, player.Position.Col], player.Position.Row + 2, player.Position.Col);

                    renderer.RenderBrick(currentMap[player.Position.Row + 1, player.Position.Col], player.Position.Row + 1, player.Position.Col);

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);

                    player.Move(Direction.Down);
                    player.Moves++;
                    SystemSounds.Asterisk.Play();
                }
                else if (currentMap[player.Position.Row + 1, player.Position.Col].Symbol == 'K' && currentMap[player.Position.Row + 2, player.Position.Col].Symbol == '*')
                {
                    currentMap[player.Position.Row + 2, player.Position.Col].Symbol = '@';
                    currentMap[player.Position.Row + 2, player.Position.Col].IsSolid = true;
                    currentMap[player.Position.Row + 1, player.Position.Col].Symbol = ' ';

                    renderer.RenderBrick(currentMap[player.Position.Row + 2, player.Position.Col], player.Position.Row + 2, player.Position.Col);

                    renderer.RenderBrick(currentMap[player.Position.Row + 1, player.Position.Col], player.Position.Row + 1, player.Position.Col);

                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);

                    player.Move(Direction.Down);
                    player.Moves++;
                    SystemSounds.Asterisk.Play();
                }
                else if (currentMap[player.Position.Row + 1, player.Position.Col].Symbol == 'K' && currentMap[player.Position.Row + 2, player.Position.Col].IsSolid)
                {
                    SystemSounds.Hand.Play();
                }
                else if (!currentMap[player.Position.Row + 1, player.Position.Col].IsSolid)
                {
                    renderer.RenderBrick(currentMap[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);
                    player.Move(Direction.Down);
                    player.Moves++;
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
    }
}
