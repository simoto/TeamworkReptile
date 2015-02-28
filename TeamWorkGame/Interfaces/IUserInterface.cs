namespace TeamWorkGame.Interfaces
{
    using System;
    using TeamWorkGame.GameObjects;

    public interface IUserInterface
    {
        void ProcessInput(IGame currentGame);
    }
}