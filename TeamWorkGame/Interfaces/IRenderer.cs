namespace TeamWorkGame.Interfaces
{
    using System;
    using System.ComponentModel;
    using TeamWorkGame.Data;
    using TeamWorkGame.GameObjects;

    public interface IRenderer : INotifyPropertyChanged
    {
        void RenderPlayer(Player hero);

        void RenderMap(SingleElement[,] matrix);

        void RenderString(string stringToWrite, ConsoleColor background, int row, int col);

        void RenderSingleElement(SingleElement element, int row, int col);

        void RenderInGameMenu();

        void RenderPlayerInfo(Player player);

        void RenderGameOver();
    }
}