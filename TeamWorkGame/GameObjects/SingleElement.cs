namespace TeamWorkGame.GameObjects
{
    using System;
    using System.ComponentModel;

    [Serializable]
    public class SingleElement : INotifyPropertyChanged
    {
        private char symbol;

        public SingleElement(ConsoleColor color, char symbol, bool isSolid)
        {
            this.Color = color;
            this.Symbol = symbol;
            this.IsSolid = isSolid;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public ConsoleColor Color { get; set; }

        public bool IsSolid { get; set; }

        public char Symbol
        {
            get
            {
                return this.symbol;
            }

            set
            {
                if (value == '#' || value == '@')
                {
                    this.IsSolid = true;
                    this.symbol = value;
                }
                else
                {
                    this.symbol = value;
                }               
            }
        }
    }
}