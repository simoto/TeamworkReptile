namespace TeamWorkGame.Data
{
    using System;
    using System.ComponentModel;

    [Serializable()]
    public class Position : INotifyPropertyChanged
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}