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
            this.pressedKey = Console.ReadKey();

            if (this.pressedKey.Key.Equals(ConsoleKey.LeftArrow))
            {
                currentGame.Move(Direction.Left);
            }
            else if (this.pressedKey.Key.Equals(ConsoleKey.RightArrow))
            {
                currentGame.Move(Direction.Right);
            }
            else if (this.pressedKey.Key.Equals(ConsoleKey.UpArrow))
            {
                currentGame.Move(Direction.Up);
            }
            else if (this.pressedKey.Key.Equals(ConsoleKey.DownArrow))
            {
                currentGame.Move(Direction.Down);
            }
            else if (this.pressedKey.Key == ConsoleKey.S)
            {
                currentGame.Save(storage);
            }
            else if (this.pressedKey.Key == ConsoleKey.E)
            {
                currentGame.Exit();
            }
            else if (this.pressedKey.Key == ConsoleKey.L)
            {
                currentGame.Load(storage, currentGame.GameName, currentGame.Player.Name, currentGame.Player.Password);
            }
            else if (this.pressedKey.Key == ConsoleKey.R)
            {
                currentGame.RestartLevel();
            }
            else if (this.pressedKey.Key == ConsoleKey.N)
            {
                currentGame.StartNewGame();
            }
        }
    }
}