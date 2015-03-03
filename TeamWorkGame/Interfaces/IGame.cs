namespace TeamWorkGame.Interfaces
{
    using System;
using System.ComponentModel;
using TeamWorkGame.Data;
using TeamWorkGame.GameObjects;

    public interface IGame : INotifyPropertyChanged
    {
        Player Player { get; set; }

        string GameName { get; }

        void Init();

        void Move(Direction deirection);

        void Save(IStorage storage);

        void Load(IStorage storage, string gameName, string userName, string password);

        void RestartLevel();

        void StartNewGame();

        void Exit();
    }
}
