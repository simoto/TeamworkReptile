namespace TeamWorkGame.GameObjects
{
    using System;

    public class SingleElement
    {
        private char symbol;

        public SingleElement(ConsoleColor color, char symbol, bool isSolid)
        {
            this.Color = color;
            this.Symbol = symbol;
            this.IsSolid = isSolid;
        }

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
