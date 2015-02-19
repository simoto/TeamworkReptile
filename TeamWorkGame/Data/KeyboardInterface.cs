namespace TeamWorkGame.Data
{
    using System;
    using TeamWorkGame.Interfaces;

    public class KeyboardInterface: IUserInterface
    {
        public void ProcessInput(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow)
            {
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
                // save and exit
                throw new NotImplementedException();
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
            else if (key.Key == ConsoleKey.E)
            {
                // end game, start from level 1
                throw new NotImplementedException();
            }
        }
    }
}
