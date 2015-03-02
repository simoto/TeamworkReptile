namespace TeamWorkGame.Data
{
    using System;
    using System.Media;
    using TeamWorkGame.GameObjects;
    using TeamWorkGame.Interfaces;

    public class KeyboardInterface : IUserInterface
    {
        private ConsoleKeyInfo pressedKey;

        public void ProcessInput(IGame currentGame, IStorage storage)
        {
            pressedKey = Console.ReadKey();

            if (pressedKey.Key.Equals(ConsoleKey.LeftArrow))
            {
                currentGame.Move(Direction.Left);
            }
            else if (pressedKey.Key.Equals(ConsoleKey.RightArrow))
            {
                currentGame.Move(Direction.Right);
            }
            else if (pressedKey.Key.Equals(ConsoleKey.UpArrow))
            {
                currentGame.Move(Direction.Up);
            }
            else if (pressedKey.Key.Equals(ConsoleKey.DownArrow))
            {
                currentGame.Move(Direction.Down);
            }
            else if (pressedKey.Key == ConsoleKey.S)
            {
                currentGame.Save(storage);
            }
            else if (pressedKey.Key == ConsoleKey.L)
            {
                currentGame.Load(storage, currentGame.GameName, currentGame.Player.Name, currentGame.Player.Password);
            }
            else if (pressedKey.Key == ConsoleKey.R)
            {
                currentGame.RestartLevel();
            }
            else if (pressedKey.Key == ConsoleKey.N)
            {
                currentGame.StartNewGame();
            }
        }
    }
}