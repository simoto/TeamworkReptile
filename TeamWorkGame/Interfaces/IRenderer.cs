namespace TeamWorkGame.Interfaces
{
    using System;
    using TeamWorkGame.Data;
    using TeamWorkGame.GameObjects;

    public interface IRenderer
    {
        void RenderHero(Hero hero);

        void RenderMap(VisualElement[,] matrix);

        void RenderString(string stringToWrite, ConsoleColor background, int row, int col);
    }
}