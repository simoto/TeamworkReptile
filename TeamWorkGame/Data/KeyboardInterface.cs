namespace TeamWorkGame.Data
{
    using System;
    using System.Media;
    using TeamWorkGame.GameObjects;
    using TeamWorkGame.Interfaces;

    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInput(ConsoleKeyInfo key, Player player, char[,] matrix)
        {
            if (key.Key == ConsoleKey.LeftArrow)
            {
                SystemSounds.Beep.Play();
                throw new NotImplementedException();
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                throw new NotImplementedException();
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                throw new NotImplementedException();
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                throw new NotImplementedException();
            }
            else if (key.Key == ConsoleKey.S)
            {
                // TODO ask player for pass/key
                var password = "TODO";

                SaveManager.Save(matrix, player);
                SystemSounds.Asterisk.Play();
                Environment.Exit(0);
            }
            else if (key.Key == ConsoleKey.L)
            {
                //load
                throw new NotImplementedException();
            }
            else if (key.Key == ConsoleKey.R)
            {
                // restart, start from same level
                throw new NotImplementedException();
            }
            else if (key.Key == ConsoleKey.N)
            {
                // end game, start from level 1
                throw new NotImplementedException();
            }
        }
    }
}
