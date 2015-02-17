namespace TeamWorkGame.Interfaces
{
    using System;
    using TeamWorkGame.Data;
    using TeamWorkGame.GameObjects;

    public interface IRenderer
    {
        void RenderHero(Player hero);

        void RenderMap(char[,] matrix);

        void RenderString(string stringToWrite, ConsoleColor background, int row, int col);
    }
}