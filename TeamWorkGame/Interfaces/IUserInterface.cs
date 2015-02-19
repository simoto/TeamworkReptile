namespace TeamWorkGame.Interfaces
{
    using System;
    using TeamWorkGame.GameObjects;

    public interface IUserInterface
    {
        void ProcessInput(ConsoleKeyInfo key, Player player, char[,] matrix);
    }
}