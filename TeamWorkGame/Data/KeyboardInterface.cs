namespace TeamWorkGame.Data
{
    using System;
    using System.Media;
    using TeamWorkGame.GameObjects;
    using TeamWorkGame.Interfaces;

    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInput(ConsoleKeyInfo pressedKey, Player player, SingleElement[,] matrix, IRenderer renderer)
        {
            if (pressedKey.Key.Equals(ConsoleKey.LeftArrow))
            {
                if (!matrix[player.Position.Row, player.Position.Col - 1].IsSolid)
                {
                    renderer.RenderBrick(matrix[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);
                    player.Move(Direction.Left);
                    player.Moves++;
                }
                else if (false) // K , and k-- is solid
                {

                } 
                else if(false) // k, and k-- is *
                {

                }
                else if (false) // K , and k-- p--
                {

                }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.RightArrow))
            {
                if (!matrix[player.Position.Row, player.Position.Col + 1].IsSolid)
                {
                    renderer.RenderBrick(matrix[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);
                    player.Move(Direction.Right);
                    player.Moves++;
                }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.UpArrow))
            {
                if (!matrix[player.Position.Row - 1, player.Position.Col].IsSolid)
                {
                    renderer.RenderBrick(matrix[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);
                    player.Move(Direction.Up);
                    player.Moves++;
                }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.DownArrow))
            {
                if (!matrix[player.Position.Row + 1, player.Position.Col].IsSolid)
                {
                    renderer.RenderBrick(matrix[player.Position.Row, player.Position.Col], player.Position.Row, player.Position.Col);
                    player.Move(Direction.Down);
                    player.Moves++;
                }
            }
            else if (pressedKey.Key == ConsoleKey.S)
            {
                // TODO ask player for pass/key
                var password = "TODO";

                SaveManager.Save(matrix, player);
                SystemSounds.Asterisk.Play();
                Environment.Exit(0);
            }
            else if (pressedKey.Key == ConsoleKey.L)
            {
                //load
                throw new NotImplementedException();
            }
            else if (pressedKey.Key == ConsoleKey.R)
            {
                // restart, start from same level
                throw new NotImplementedException();
            }
            else if (pressedKey.Key == ConsoleKey.N)
            {
                // end game, start from level 1
                throw new NotImplementedException();
            }
        }
    }
}
