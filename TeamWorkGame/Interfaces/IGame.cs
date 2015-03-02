namespace TeamWorkGame.Interfaces
{
    using System;
using System.ComponentModel;
using TeamWorkGame.Data;
using TeamWorkGame.GameObjects;

    public interface IGame : INotifyPropertyChanged
    {
        void Init();

        void Move(Direction deirection);

        void Save();

        void Load(string userName, string password);

        void RestartLevel();

        void StartNewGame();

        Player Player { get; set; }
    }
}
